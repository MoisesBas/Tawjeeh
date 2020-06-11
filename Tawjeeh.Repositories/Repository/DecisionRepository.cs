using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class DecisionRepository : BaseRepository<Decision>,
        IDecisionRepository
    {
        public DecisionRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateDecision(Decision decision)
        {
            decision.CreatedOn = DateTime.Now;
            decision.IsActive = true;
            decision.IsDeleted = false;
            return base.Create(decision);
        }

        public int DeleteDecision(Decision decision)
        {          
            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Execute("DeleteDecision", new { @decisionId = decision.Id, @UpdatedBy = decision.UpdatedBy },
                    commandType: CommandType.StoredProcedure);
                if (result == -1) result = 1;
                return result;
            }
        }

        public IList<Decision> GetDecisionAll()
        {
            var _result = this.GetMultiple("spGetDecisionAll",true,null,
                                                r => r.Read<Decision>(),
                                                r => r.Read<DecisionTrans>(),
                                                r => r.Read<DecisionMultimedia>(),
                                                r => r.Read<Article>(),
                                                r => r.Read<Law>());
          
                var decisions = _result.Item1.ToList();
                var decisiontrans = _result.Item2.ToList();
                var decisionmultimedia = _result.Item3.ToList();
                var articles = _result.Item4.ToList();
                var laws = _result.Item5.ToList();

                var decision = (from c in decisions
                               select new Decision
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Description = c.Description,
                                   ArticleId = c.ArticleId,
                                   IsActive = c.IsActive,
                                   IsDeleted = c.IsDeleted,
                                   CreatedBy = c.CreatedBy,
                                   CreatedOn = c.CreatedOn,
                                   Year = c.Year,
                                   UpdatedBy = c.UpdatedBy,
                                   UpdatedOn = c.UpdatedOn,
                                   DecisionTranslations = (from dt in decisiontrans
                                                           where dt.DecisionId == c.Id
                                                         select dt).ToList(),
                                   MultimediaDecisions = (from ma in decisionmultimedia
                                                         where ma.DecisionId == c.Id
                                                         select ma).ToList(),
                                   Articles = (from a in articles
                                               join d in decisions on a.Id equals d.ArticleId
                                               where d.Id == c.Id
                                               select a).FirstOrDefault(),
                                   Laws = (from l in laws
                                           join a in articles on l.Id equals a.LawId
                                           join d in decisions on a.Id equals d.ArticleId
                                           where d.Id == c.Id
                                           select l).FirstOrDefault()

                               }).ToList();
                return decision.Count > 0 ? decision : new List<Decision>();
            
        }

        public IList<Decision> GetDecisionByArticleId(long articleId)
        {           

            var _result = this.GetMultiple("spGetDecisionByArticleId", true, new { @articleId= articleId },
                                                 r => r.Read<Decision>(),
                                                 r => r.Read<DecisionTrans>(),
                                                 r => r.Read<DecisionMultimedia>(),
                                                 r => r.Read<Article>(),
                                                 r => r.Read<Law>());          
               
            var decisions = _result.Item1;
            var decisiontrans = _result.Item2;
            var decisionmultimedia = _result.Item3;
            var article = _result.Item4;
            var law = _result.Item5;

            var decision = (from c in decisions
                                select new Decision
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    DecisionNo = c.DecisionNo,
                                    Description = c.Description,
                                    ArticleId = c.ArticleId,
                                    IsActive = c.IsActive,
                                    IsDeleted = c.IsDeleted,
                                    CreatedBy = c.CreatedBy,
                                    CreatedOn = c.CreatedOn,
                                    UpdatedBy = c.UpdatedBy,
                                    UpdatedOn = c.UpdatedOn,
                                    Year = c.Year,
                                    DecisionTranslations = (from dt in decisiontrans
                                                            where dt.DecisionId == c.Id
                                                            select dt).ToList(),
                                    MultimediaDecisions = (from ma in decisionmultimedia
                                                           where ma.DecisionId == c.Id
                                                           select ma).ToList(),
                                    Laws = (from l in law                                           
                                            select l).FirstOrDefault(),

                                    Articles = (from a in article
                                                where a.Id == c.ArticleId
                                                select a).FirstOrDefault()

                                }).ToList();
                return decision.Count > 0 ? decision : new List<Decision>();
            
        }
        public IList<Decision> GetDecisionByArticleIdAndLangId(long articleId, int langId)
        {       

            var _result = this.GetMultiple("spGetDecisionByArticleIdAndLangId", true,
                          new { @articleId = articleId,@langId=langId },
                                r => r.Read<Decision>(),
                                r => r.Read<DecisionTrans>(),
                                r => r.Read<DecisionMultimedia>(),
                                r => r.Read<Article>(),
                                r => r.Read<ArticleTrans>(),
                                r => r.Read<Law>(),
                                r => r.Read<LawTrans>()
                                );

            var decisions = _result.Item1.ToList();
            var decisiontrans = _result.Item2.ToList();
            var decisionmultimedia = _result.Item3.ToList();            
            var article = _result.Item4.ToList();
            var articleTrans = _result.Item5.ToList();
            var law = _result.Item6.ToList();           
            var lawTrans = _result.Item7.ToList();

            var decision = (from c in decisions
                                select new Decision
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Description = c.Description,
                                    ArticleId = c.ArticleId,
                                    IsActive = c.IsActive,
                                    IsDeleted = c.IsDeleted,
                                    CreatedBy = c.CreatedBy,
                                    CreatedOn = c.CreatedOn,
                                    UpdatedBy = c.UpdatedBy,
                                    UpdatedOn = c.UpdatedOn,
                                    Year = c.Year,
                                    DecisionTranslations = (from dt in decisiontrans
                                                            where dt.DecisionId == c.Id
                                                            select dt).ToList(),
                                    MultimediaDecisions = (from ma in decisionmultimedia
                                                           where ma.DecisionId == c.Id
                                                           select ma).ToList(),
                                    Laws = (from l in law
                                            select new Law {
                                                Id = l.Id,
                                                Name = l.Name,
                                                Description = l.Description,
                                                IsActive = l.IsActive,
                                                IsDeleted = l.IsDeleted,
                                                CreatedOn = l.CreatedOn,
                                                CreatedBy = l.CreatedBy,
                                                UpdatedBy = l.UpdatedBy,
                                                UpdatedOn = l.UpdatedOn,
                                                LawTranslation = lawTrans.Select(x=>x).ToList()
                                            }).FirstOrDefault(),

                                    Articles = (from a in article
                                                where a.Id == c.ArticleId
                                                select new Article {
                                                    Id = a.Id,
                                                    Name = a.Name,
                                                    Description = a.Description,
                                                    ArticleNo = a.ArticleNo,
                                                    LawId = a.LawId,
                                                    IsActive = a.IsActive,
                                                    IsDeleted = a.IsDeleted,
                                                    CreatedOn = a.CreatedOn,
                                                    CreatedBy = a.CreatedBy,
                                                    UpdatedBy = a.UpdatedBy,
                                                    UpdatedOn = a.UpdatedOn,
                                                    ArticleTranslation = articleTrans.Select(x => x).ToList()
                                                }).FirstOrDefault()

                                }).ToList();
                return decision.Count > 0 ? decision : new List<Decision>();            
        }

        public Decision GetDecisionById(long id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT d.* FROM tblDecision d WHERE Id =@id and d.IsDeleted=0 ";
                var result = _conn.Query<Decision>(query, new { @id = id});
                return result.FirstOrDefault();
            }
        }

        public Decision GetDecisionByName(string name, long articleId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT d.* FROM tblDecision d WHERE d.Name=@name and d.ArticleId = @articleId and d.IsDeleted=0";
                var result = _conn.Query<Decision>(query, new { @name = name, @articleId = articleId });
                return result.FirstOrDefault();
            }
        }

        public Decision GetDecisionLangIdAndId(long id, int langId)
        {            
            var _result = this.GetMultiple("spGetDecisionLangIdAndId", true,new { @Id = id, @langId = langId },
                                              r => r.Read<Decision>(),
                                              r => r.Read<DecisionTrans>(),
                                              r => r.Read<DecisionMultimedia>());
            var decisions = _result.Item1;
            var decisiontrans = _result.Item2;
            var decisionmultimedia = _result.Item3;          

            var decision = (from c in decisions
                                select new Decision
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Description = c.Description,
                                    ArticleId = c.ArticleId,
                                    IsActive = c.IsActive,
                                    IsDeleted = c.IsDeleted,
                                    CreatedBy = c.CreatedBy,
                                    CreatedOn = c.CreatedOn,
                                    UpdatedBy = c.UpdatedBy,
                                    UpdatedOn = c.UpdatedOn,
                                    Year = c.Year,
                                    DecisionTranslations = (from dt in decisiontrans
                                                            where dt.DecisionId == c.Id
                                                            select dt).ToList(),
                                    MultimediaDecisions = (from ma in decisionmultimedia
                                                           where ma.DecisionId == c.Id
                                                           select ma).ToList()
                                }).FirstOrDefault();
                return decision != null ? decision : new Decision();       
           
        }

        public int UpdateDecision(Decision decision)
        {
            decision.UpdatedOn = DateTime.Now;
            return base.Update(decision);
        }
    }
}
