using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class ArticleTransRepository : BaseRepository<ArticleTrans>, 
        IArticleTransRepository
    {
        public ArticleTransRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateArticleTrans(ArticleTrans article)
        {
            article.CreatedOn = DateTime.Now;
            article.IsActive = true;
            article.IsDeleted = false;            
            return base.Create(article);
        }

        public int DeleteArticleTrans(ArticleTrans article)
        {           
            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Execute("DeleteArticlesTrans", new { @ArticleTransId = article.Id, @LangId= article.LangId, @UpdatedBy = article.UpdatedBy },
                    commandType: CommandType.StoredProcedure);
                if (result == -1) result = 1;
                return result;
            }
        }


        public Task<IEnumerable<ArticleTrans>> GetArticleAllTrans()
        {
            return base.GetAllAsync();
        }

        public ArticleTrans GetArticleTransById(int id)
        {
            var query = @"Select at.* FROM tblArticleTrans at WHERE at.Id = @id and at.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<ArticleTrans>(query, new { @id=id }).FirstOrDefault();
            }                 
        }

        public ArticleTrans GetArticleTransByName(Int64 articleId, string name, int langId)
        {
            var query = @"SELECT a.*  FROM tblArticleTrans a
                          WHERE a.Name = @name And a.ArticleId =@articleId And a.LangId=@langId and a.IsDeleted=0";

            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<ArticleTrans>(query, new { @name = name, @langId = langId, @articleId= articleId }).FirstOrDefault();
            }
        }
        public int UpdateArticleTrans(ArticleTrans article)
        {
            article.UpdatedOn = DateTime.Now;
            return base.Update(article);
        }

        public ArticleTrans GetArticleTransLangIdAndId(long id, int langId)
        {
            var query = @"Select at.* FROM tblArticleTrans at WHERE at.Id = @id and at.LangId = @langId and at.IsDeleted=0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<ArticleTrans>(query, new { @id = id, @langId = langId }).FirstOrDefault();
            }
        }
        public ArticleTrans GetArticleLangIdAndArticleId(long articleId, int langId)
        {
            var query = @"Select at.* FROM tblArticleTrans at WHERE at.ArticleId = @id and at.LangId = @langId and at.IsDeleted=0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<ArticleTrans>(query, new { @id = articleId, @langId = langId }).FirstOrDefault();
            }
        }
        public IList<ArticleTrans> GetArticleByLawIdAndLangId(long lawId, int langId)
        {
            var query = @"SELECT at.* FROM tblArticleTrans at inner join
                          tblArticle a on at.ArticleId = a.Id
                          WHERE a.LawId = @lawId and at.LangId = @langId and at.IsDeleted=0 and a.IsDeleted=0;
                        
                          SELECT am.* FROM tblArticleMultimedia am inner join
                          tblArticle a on am.ArticleId = a.Id
                          WHERE a.LawId = @lawId and am.LangId = @langId and am.IsDeleted=0 and a.IsDeleted=0;
                          
                          SELECT dt.* FROM tblDecisionTrans dt inner join
                          tblArticle a on dt.ArticleId = a.Id
                          WHERE a.LawId = @lawId and dt.LangId = @langId and dt.IsDeleted=0 and a.IsDeleted=0

                         SELECT dm.* FROM tblDecisionMultimedia dm inner join
                          tblDecision d on dm.DecisionId = d.Id inner join 
                          tblArticle a on d.ArticleId = a.Id
                          WHERE dm.LangId = @langId and a.LawId = @lawId and a.IsDeleted=0 and dm.IsDeleted=0 and d.IsDeleted=0                     
                          ";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query, new { @lawId = lawId, @langId = langId });              
                var articletrans = result.Read<ArticleTrans>().ToList();
                var articlemultimedia = result.Read<ArticleMultimedia>().ToList();
                var decisiontrans = result.Read<DecisionTrans>().ToList();
                var decisionmultimedia = result.Read<DecisionMultimedia>().ToList();

                var trans = (from at in articletrans
                               select new ArticleTrans
                               {
                                   Id = at.Id,
                                   Name = at.Name,
                                   Description = at.Description,
                                   ArticleId = at.ArticleId,
                                   ArticleNo = at.ArticleNo,
                                   LangId = at.LangId,
                                   IsActive = at.IsActive,
                                   IsDeleted = at.IsDeleted,
                                   CreatedBy = at.CreatedBy,
                                   CreatedOn = at.CreatedOn,
                                   UpdatedBy = at.UpdatedBy,
                                   UpdatedOn = at.UpdatedOn,                                  
                                   ArticleMultimedia = (from ma in articlemultimedia
                                                         where ma.ArticleId == at.ArticleId && ma.LangId == at.LangId
                                                         select ma).ToList(),
                                   DecisionTrans = (from dt in decisiontrans
                                                    where dt.ArticleId == at.ArticleId 
                                                    && dt.LangId == at.LangId
                                                    select dt).ToList(),
                                   DecisionMultimedia = (from dm in decisionmultimedia
                                                         join dt in decisiontrans on dm.DecisionId equals dt.DecisionId
                                                         where dt.ArticleId == at.ArticleId && dt.LangId == at.LangId
                                                         select dm).ToList()

                               }).ToList();
                return trans.Count > 0 ? trans : new List<ArticleTrans>();
            }
        }

        public IList<ArticleTrans> GetArticleByLangId(int langId)
        {
            var query = @"SELECT at.* FROM tblArticleTrans at inner join
                          tblArticle a on at.ArticleId = a.Id
                          WHERE at.LangId = @langId and at.IsDeleted=0 and a.IsDeleted=0;
                        
                          SELECT am.* FROM tblArticleMultimedia am inner join
                          tblArticle a on am.ArticleId = a.Id
                          WHERE am.LangId = @langId and am.IsDeleted=0 and a.IsDeleted=0;
                          
                          SELECT dt.* FROM tblDecisionTrans dt inner join
                          tblArticle a on dt.ArticleId = a.Id
                          WHERE dt.LangId = @langId and dt.IsDeleted=0 and a.IsDeleted=0
                          
                          SELECT dm.* FROM tblDecisionMultimedia dm inner join
                          tblDecision d on dm.DecisionId = d.Id
                          WHERE dm.LangId = @langId and dm.IsDeleted=0 and d.IsDeleted=0;                     
                          ";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query, new { @langId = langId });
                var articletrans = result.Read<ArticleTrans>().ToList();
                var articlemultimedia = result.Read<ArticleMultimedia>().ToList();
                var decisiontrans = result.Read<DecisionTrans>().ToList();
                var decisionmultimedia = result.Read<DecisionMultimedia>().ToList();

                var trans = (from at in articletrans
                             select new ArticleTrans
                             {
                                 Id = at.Id,
                                 Name = at.Name,
                                 Description = at.Description,
                                 ArticleId = at.ArticleId,
                                 ArticleNo = at.ArticleNo,
                                 LangId = at.LangId,
                                 IsActive = at.IsActive,
                                 IsDeleted = at.IsDeleted,
                                 CreatedBy = at.CreatedBy,
                                 CreatedOn = at.CreatedOn,
                                 UpdatedBy = at.UpdatedBy,
                                 UpdatedOn = at.UpdatedOn,
                                 ArticleMultimedia = (from ma in articlemultimedia
                                                      where ma.ArticleId == at.ArticleId && ma.LangId == at.LangId
                                                      select ma).ToList(),
                                 DecisionTrans = (from dt in decisiontrans
                                                  where dt.ArticleId == at.ArticleId
                                                  && dt.LangId == at.LangId
                                                  select dt).ToList(),
                                 DecisionMultimedia = (from dm in decisionmultimedia
                                                       join dt in decisiontrans on dm.DecisionId equals dt.DecisionId
                                                       where dt.ArticleId == at.ArticleId && dt.LangId == at.LangId
                                                       select dm).ToList()

                             }).ToList();
                return trans.Count > 0 ? trans : new List<ArticleTrans>();
            }
        }

        public ArticleTrans GetArticleTransByIdAndLangId(long articleId, int langId)
        {
            throw new NotImplementedException();
        }
    }
}
