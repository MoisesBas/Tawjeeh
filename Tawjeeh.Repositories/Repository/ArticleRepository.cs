using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using System.Data;

namespace Tawjeeh.Repositories.Repository
{
    public class ArticleRepository: BaseRepository<Article>, 
        IArticleRepository
    {
        public ArticleRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {
            
        }

        public int CreateArticle(Article article)
        {
            article.CreatedOn = DateTime.Now;
            article.IsActive = true;
            article.IsDeleted = false;
            return base.Create(article);
        }
        public int DeleteArticle(Article article)
        {           
            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Execute("DeleteArticles", new { @ArticleId = article.Id, @UpdatedBy = article.UpdatedBy },
                    commandType: CommandType.StoredProcedure);

                if (result == -1) result = 1;
                return result;
            }
        }
        public IList<Article> GetArticleAll()
        {
            var query = @"SELECT * FROM tblArticle a WHERE a.IsDeleted=0;
                          SELECT * FROM tblArticleTrans at WHERE at.IsDeleted=0;
                          SELECT * FROM tblArticleMultimedia am WHERE am.IsDeleted=0;
                          SELECT d.* FROM tblDecision d inner join 
                                 tblArticle a on d.ArticleId = a.Id
                           WHERE d.IsDeleted = 0 and a.IsDeleted = 0;";

            using (var _conn = _connectionFactory.GetConnection)
            {                
                var result = _conn.QueryMultiple(query);
                var artilces = result.Read<Article>().ToList();
                var articletrans = result.Read<ArticleTrans>().ToList();
                var articlemultimedia = result.Read<ArticleMultimedia>().ToList();
                var decisions = result.Read<Decision>().ToList();
                var article = (from c in artilces
                              select new Article
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  Description = c.Description,
                                  LawId = c.LawId,
                                  IsActive = c.IsActive,
                                  IsDeleted = c.IsDeleted,
                                  CreatedBy = c.CreatedBy,
                                  CreatedOn = c.CreatedOn,
                                  UpdatedBy = c.UpdatedBy,
                                  UpdatedOn = c.UpdatedOn,
                                  ArticleTranslation = (from ct in articletrans
                                                        where ct.ArticleId == c.Id
                                                        select ct).ToList(),
                                  MultimediaArticles = (from ma in articlemultimedia
                                                        where ma.ArticleId == c.Id
                                                        select ma).ToList(),
                                  Decisions = (from d in decisions
                                               where d.ArticleId == c.Id
                                               select d).ToList()

                              }).ToList();
                return article.Count > 0 ? article : new List<Article>();
            }
          
        }
        public IList<Article> GetArticleByLawId(long lawId)
        {
            var query = @"SELECT * FROM tblArticle a WHERE a.LawId = @lawId and a.IsDeleted=0;
                          SELECT at.* FROM tblArticleTrans at inner join
                          tblArticle a on at.ArticleId = a.Id
                          WHERE a.LawId = @lawId and at.IsDeleted=0 and a.IsDeleted=0;

                          SELECT am.* FROM tblArticleMultimedia am inner join
                          tblArticle a on am.ArticleId = a.Id
                          WHERE a.LawId = @lawId and am.IsDeleted=0 and a.IsDeleted=0;
                          
                          SELECT d.* FROM tblDecision d inner join 
                          tblArticle a on d.ArticleId = a.Id 
                          WHERE a.LawId = @lawId and d.IsDeleted=0 and a.IsDeleted=0;";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query,new { @lawId= lawId });
                var articles = result.Read<Article>().ToList();
                var articletrans = result.Read<ArticleTrans>().ToList();
                var articlemultimedia = result.Read<ArticleMultimedia>().ToList();
                var decisions = result.Read<Decision>().ToList();

                var article = (from c in articles
                               select new Article
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Description = c.Description,
                                   LawId = c.LawId,
                                   IsActive = c.IsActive,
                                   IsDeleted = c.IsDeleted,
                                   CreatedBy = c.CreatedBy,
                                   CreatedOn = c.CreatedOn,
                                   UpdatedBy = c.UpdatedBy,
                                   UpdatedOn = c.UpdatedOn,
                                   ArticleTranslation = (from ct in articletrans
                                                         where ct.ArticleId == c.Id
                                                         select ct).ToList(),
                                   MultimediaArticles = (from ma in articlemultimedia
                                                         where ma.ArticleId == c.Id
                                                         select ma).ToList(),
                                   Decisions = (from ds in decisions
                                                where ds.ArticleId == c.Id
                                                select ds).ToList()

                               }).ToList();
                return article.Count > 0 ? article.ToList(): new List<Article>();
            }
        }
       
        public Article GetArticleById(long id)
        {           
            var query = @"SELECT * FROM tblArticle a WHERE a.Id = @id and a.IsDeleted=0;
                          SELECT * FROM tblArticleTrans at WHERE at.ArticleId = @id and at.IsDeleted=0;
                          SELECT * FROM tblArticleMultimedia am WHERE am.ArticleId = @id and am.IsDeleted=0;
                          SELECT d.* FROM tblDecision d inner join 
                          tblArticle a on d.ArticleId = a.Id 
                          WHERE a.Id = @id and d.IsDeleted=0 and a.IsDeleted=0;";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query, new { @id = id});
                var articles = result.Read<Article>().ToList();
                var articletrans = result.Read<ArticleTrans>().ToList();
                var articlemultimedia = result.Read<ArticleMultimedia>().ToList();

                var article = (from c in articles
                               select new Article
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Description = c.Description,
                                   LawId = c.LawId,
                                   IsActive = c.IsActive,
                                   IsDeleted = c.IsDeleted,
                                   CreatedBy = c.CreatedBy,
                                   CreatedOn = c.CreatedOn,
                                   UpdatedBy = c.UpdatedBy,
                                   UpdatedOn = c.UpdatedOn,
                                   ArticleTranslation = (from ct in articletrans
                                                         where ct.ArticleId == c.Id
                                                         select ct).ToList(),
                                   MultimediaArticles = (from ma in articlemultimedia
                                                         where ma.ArticleId == c.Id
                                                         select ma).ToList()

                               }).ToList();
                return article.Count > 0 ? article.FirstOrDefault() : new Article();
            }           
        }
        public Article GetArticleByName(string name, Int64 lawId)
        {
            var query = @"SELECT *  FROM tblArticle a
                          WHERE a.Name = @name And a.LawId =@lawId and a.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<Article>(query, new { @name = name, @lawId = lawId }).FirstOrDefault();
            }
        }
        public Article GetArticleLangIdAndId(long id, int langId)
        {
            var query = @"SELECT a.* FROM tblArticle a inner join 
                                        tblArticleTrans at on a.Id = at.ArticleId 
                                   WHERE a.Id = @id and at.LangId = @langId and a.IsDeleted=0 and at.IsDeleted=0;

                          SELECT at.* FROM tblArticleTrans at
                                   WHERE at.ArticleId = @id and at.LangId = @langId and at.IsDeleted=0;

                          SELECT am.* FROM tblArticleMultimedia am WHERE am.ArticleId = @id and am.LangId=@langId and am.IsDeleted=0";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query, new { @id = id, @langId = langId });
                var articles = result.Read<Article>().ToList();
                var articletrans = result.Read<ArticleTrans>().ToList();              
                var articlemultimedia = result.Read<ArticleMultimedia>().ToList();

                var article = (from c in articles
                               select new Article
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Description = c.Description,
                                   LawId = c.LawId,
                                   IsActive = c.IsActive,
                                   IsDeleted = c.IsDeleted,
                                   CreatedBy = c.CreatedBy,
                                   CreatedOn = c.CreatedOn,
                                   UpdatedBy = c.UpdatedBy,
                                   UpdatedOn = c.UpdatedOn,
                                   ArticleTranslation = (from ct in articletrans
                                                         where ct.ArticleId == c.Id
                                                         select ct).ToList(),
                                   MultimediaArticles = (from ma in articlemultimedia
                                                         where ma.ArticleId == c.Id
                                                         select ma).ToList()

                               }).ToList();
                return article.Count > 0 ? article.FirstOrDefault() : new Article();
           }          
           
        }
        public int UpdateArticle(Article article)
        {
            article.UpdatedOn = DateTime.Now;
            return base.Update(article);
        }
    }
}
