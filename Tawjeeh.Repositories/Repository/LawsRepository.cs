using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class LawsRepository : BaseRepository<Law>, 
        ILawRepository
    {
        public LawsRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public int CreateLaw(Law laws)
        {
            laws.CreatedOn = DateTime.Now;
            laws.IsActive = true;
            laws.IsDeleted = false;
            return base.Create(laws);
        }

        public int DeleteLaw(Law laws)
        {            
            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Execute("DeleteLaws", new { @LawId = laws.Id, @UpdatedBy = laws.UpdatedBy },
                    commandType: CommandType.StoredProcedure);
                if (result == -1) result = 1;
                return result;
            }
        }

        public IList<Law> GetAllLaws()
        {
            
            var query = @"Select w.* from tblLaw w WHERE w.IsActive = 1 and w.IsDeleted=0;                       

                          Select a.* from tblArticle a 
                          inner join tblLaw l on a.LawId = l.Id
                          where a.IsActive = 1 and a.IsDeleted=0;                         

                          Select d.* from tblDecision d inner join 
                          tblArticle a on d.ArticleId = a.Id inner join 
						  tblLaw l on a.LawId = l.Id
                          where d.IsActive = 1 and d.IsDeleted=0;

                          select dm.* from tblDecisionMultimedia dm where dm.IsActive=1 AND dm.IsDeleted=0;
                          select am.* from tblArticleMultimedia am where am.IsActive=1 AND am.IsDeleted=0;";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query);
                var law = result.Read<Law>().ToList();              
                var article = result.Read<Article>().ToList();               
                var decision = result.Read<Decision>().ToList();
                var decisionMulti = result.Read<DecisionMultimedia>().ToList();
                var articleMulti = result.Read<ArticleMultimedia>().ToList();

                var output = (from l in law
                              select new Law
                              {
                                  Id = l.Id,
                                  Name = l.Name,
                                  Description = l.Description,
                                  IsActive = l.IsActive,
                                  IsDeleted = l.IsDeleted,
                                  CreatedOn = l.CreatedOn,
                                  CreatedBy = l.CreatedBy,
                                  UpdatedOn = l.UpdatedOn,
                                  UpdatedBy = l.UpdatedBy,
                                  //LawTranslation = (from lt in lawtrans
                                  //                  where lt.LawId == l.Id
                                  //                  select lt).ToList(),
                                  Articles = (from a in article
                                              where a.LawId == l.Id
                                              select new Article
                                              {
                                                  Id = a.Id,
                                                  Name = a.Name,
                                                  Description = a.Description,
                                                  //ArticleTranslation = (from at in articletrans
                                                  //                      join a1 in article on at.ArticleId equals a1.Id
                                                  //                      select at).ToList(),
                                                  LawId = a.LawId,
                                                  IsActive = a.IsActive,
                                                  IsDeleted = a.IsDeleted,
                                                  CreatedOn = a.CreatedOn,
                                                  CreatedBy = a.CreatedBy,
                                                  UpdatedOn = a.UpdatedOn,
                                                  UpdatedBy = a.UpdatedBy

                                              }).ToList(),
                                  DecisionCnt = (from d in decision
                                                 join a in article on d.ArticleId equals a.Id
                                                 where a.LawId == l.Id
                                                 select d).ToList().Count(),

                                  MultimediaCnt =  ((from am in articleMulti
                                                                  join ar in article on am.ArticleId equals ar.Id
                                                                  where ar.LawId == l.Id && am.IsDeleted == false
                                                                  select am.Id).Count() + (from dm in decisionMulti
                                                                                           join d in decision on dm.DecisionId equals d.Id
                                                                                           join a in article on d.ArticleId equals a.Id
                                                                                           where a.LawId == l.Id
                                                                                           select dm.Id).Count())                    


                              }).ToList();
                return output;
            }

        }

        public Law GetLawByIdAndLangId(Int64 id, int langId)
        {
            var result = new Law();
            var query = @"Select u.*,lt.*
                          FROM tblLaw u inner join tblLawTrans 
                          lt on u.Id = lt.LawId 
                          Where u.Id = @id And lt.LangId = @langId";

            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<Law, LawTrans, Law>
                (query, (t, l) =>
                {
                    t.LawTranslation.Add(l);
                    return t;
                }, new { @id = @id, @langId = langId }).FirstOrDefault();
            }

        }

        public IEnumerable<Law> GetAll(int langId)
        {
            var query = @"Select l.* FROM tblLaw l 
                           inner join tblLawTrans lt on l.Id = lt.LawId
                          WHERE lt.LangId =@langId and lt.IsDeleted = 0;
                 
                          Select lt.* from tblLawTrans lt inner join tblLaw l on lt.LawId = l.Id
                          WHERE lt.LangId =@langId and lt.IsDeleted = 0;

                          SELECT * FROM 
                            (SELECT  a.Id, a.Name, a.Description, a.LawId, a.ArticleNo, a.IsActive, a.IsDeleted, a.CreatedOn, a.CreatedBy, 
                            rn=Row_Number() OVER (PARTITION BY  a.Id ORDER BY  a.Id), a.UpdatedOn, a.UpdatedBy
                            FROM            dbo.tblArticle AS a INNER JOIN
                         dbo.tblLaw AS l ON a.LawId = l.Id INNER JOIN
                         dbo.tblArticleTrans AS at ON a.Id = at.ArticleId
                         WHERE (at.LangId = @langId) AND (a.IsDeleted = 0)) as result
                         WHERE rn=1;

                          select at.* from tblArticleTrans at inner join tblArticle a on at.ArticleId = a.Id
                           inner join tblLaw l on a.LawId = l.Id
                          WHERE at.LangId = @langId and at.IsDeleted = 0;";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query, new { @langId = langId });
                var law = result.Read<Law>().ToList();
                var lawtrans = result.Read<LawTrans>().ToList();
                var article = result.Read<Article>().ToList();
                var articletrans = result.Read<ArticleTrans>().ToList();

                var output = (from l in law
                              select new Law
                              {
                                  Id = l.Id,
                                  Name = l.Name,
                                  Description = l.Description,
                                  IsActive = l.IsActive,
                                  IsDeleted = l.IsDeleted,
                                  CreatedOn = l.CreatedOn,
                                  CreatedBy = l.CreatedBy,
                                  UpdatedOn = l.UpdatedOn,
                                  UpdatedBy = l.UpdatedBy,
                                  LawTranslation = (from lt in lawtrans
                                                    where lt.LawId == l.Id
                                                    select lt).ToList(),
                                  Articles = (from a in article
                                              where a.LawId == l.Id
                                              select new Article
                                              {
                                                  Id = a.Id,
                                                  Name = a.Name,
                                                  Description = a.Description,
                                                  ArticleTranslation = (from at in articletrans
                                                                        where at.ArticleId == a.Id
                                                                        select at).ToList(),
                                                  LawId = a.LawId,
                                                  IsActive = a.IsActive,
                                                  IsDeleted = a.IsDeleted,
                                                  CreatedOn = a.CreatedOn,
                                                  CreatedBy = a.CreatedBy,
                                                  UpdatedOn = a.UpdatedOn,
                                                  UpdatedBy = a.UpdatedBy

                                              }).ToList()

                              }).ToList();
                return output;



            }


        }
        public Law GetLawById(Int64 id)
        {
            var result = new Law();
            var query = @"Select u.*,lt.*
                          FROM tblLaw u inner join tblLawTrans 
                          lt on u.Id = lt.LawId 
                          Where u.Id = @id and u.IsDeleted = 0";

            using (var _conn = _connectionFactory.GetConnection)
            {
                return Utilities.QueryParentChild<Law, LawTrans, long>(_conn,
                    query, a => a.Id, a => a.LawTranslation, new { @id = id }).FirstOrDefault();
            }
        }
        public int UpdateLaw(Law laws)
        {
            laws.UpdatedOn = DateTime.Now;
            return base.Update(laws);
        }
        public Law GetLawByName(string lawName)
        {

            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = @"SELECT * FROM tblLaw WHERE Name=@lawName and IsDeleted = 0";
                var result = _conn.Query<Law>(query, new { @lawName = lawName });
                return result.FirstOrDefault();
            }

        }
    }
}
