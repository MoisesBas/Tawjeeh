using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class ArticleMultimediaRepository : BaseRepository<ArticleMultimedia>,
        IArticleMultimediaRepository
    {
        public ArticleMultimediaRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateArticleMultimedia(ArticleMultimedia articlemultimedia)
        {
            articlemultimedia.CreatedOn = DateTime.Now;
            articlemultimedia.IsActive = true;
            articlemultimedia.IsDeleted = false;
            return base.Create(articlemultimedia);
        }

        public int DeleteArticleMultimedia(ArticleMultimedia articlemultimedia)
        {
            articlemultimedia.UpdatedOn = DateTime.Now;
            articlemultimedia.IsDeleted = true;
            return base.Update(articlemultimedia);
        }

        public IList<ArticleMultimedia> GetArticleMultimediaAll()
        {          
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = @"Select * FROM tblArticleMultimedia am where am.IsDeleted=0;";
                return _conn.Query<ArticleMultimedia>(query).ToList();
            }
        }

        public IList<ArticleMultimedia> GetArticleMultimediaByArticleId(long articleId)
        {           
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = @"Select * FROM tblArticleMultimedia am 
                          WHERE am.ArticleId = @articleId and am.IsDeleted=0;";
                return _conn.Query<ArticleMultimedia>(query, new { @articleId = articleId}).ToList();
            }
        }

        public IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId)
        {           
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = @"Select * FROM tblArticleMultimedia am 
                          WHERE am.ArticleId = @articleId and am.LangId=@langId and am.IsDeleted=0 And am.IsMobile = 1";
                return _conn.Query<ArticleMultimedia>(query, new { @articleId = articleId, @langId = langId }).ToList();
            }
        }

        public IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId, long lawId)
        {
            var query = @"Select am.*, a.* from tblArticleMultimedia am inner join tblArticle a
                        on am.ArticleId = a.Id 
                          WHERE am.ArticleId = @articleId and am.LangId=@langId and am.IsDeleted=0 
                       and a.LawId = @lawId
                       and am.IsDeleted=0 and a.IsDeleted=0;";

            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<ArticleMultimedia, Article, ArticleMultimedia>
                (query, (articlemultimedia, article) =>
                {
                    articlemultimedia.Article = article;
                    return articlemultimedia;
                }, new { @articleId = articleId,@langId = langId, @lawId=lawId }).ToList();
            }
        }

        public ArticleMultimedia GetArticleMultimediaById(long multimediaId)
        {            
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = @"Select * FROM tblArticleMultimedia am 
                          WHERE am.Id = @Id and am.IsDeleted=0;";
                var artmedia = _conn.Query<ArticleMultimedia>(query, new { @Id = multimediaId }).FirstOrDefault();               
                return artmedia;
            }
        }

        public ArticleMultimedia GetArticleMultimediaByName(string name, long articleId)
        {
            throw new NotImplementedException();
        }

        public ArticleMultimedia GetArticleMultimediaLangIdAndId(long id, long articleId, int langId)
        {
            throw new NotImplementedException();
        }

        public MultimediaTopVideo GetMultimediaTopVideo()
        {
           
                var query = @"SELECT TOP 1 am.* FROM dbo.tblArticleMultimedia am WHERE am.FileType = 1 AND am.IsActive = 1 AND am.IsDeleted = 0 ORDER BY am.Id DESC;
                          SELECT TOP 3 am.* FROM dbo.tblArticleMultimedia am WHERE am.FileType = 1 AND am.IsActive = 1 AND am.IsDeleted = 0 ORDER BY am.CntViews DESC;
                          SELECT TOP 6 a.* FROM dbo.tblArticle a WHERE a.IsActive = 1 AND a.IsDeleted = 0 ORDER BY a.Id DESC;";
            
          
                var result = base.GetMultiple(query,false,null,
                    x=>x.Read<ArticleMultimedia>(),
                    x=>x.Read<ArticleMultimedia>(),
                    x=>x.Read<ArticleTrans>());

                var topVideo = result.Item1 != null ? result.Item1.ToList(): new List<ArticleMultimedia>();
                var recentVideo = result.Item2 != null ?  result.Item2.ToList(): new List<ArticleMultimedia>();
                var article = result.Item3 != null ? result.Item3.ToList(): new List<ArticleTrans>();
                return new MultimediaTopVideo()
                {
                    TopVideo = topVideo.FirstOrDefault(),
                    RecentVideo = recentVideo,
                    Article = article                   
                };          

        }

        public MultimediaTopVideo GetMultimediaTopVideoByLangId(int langId)
        {
            var query = @"SELECT TOP 1 am.* FROM dbo.tblArticleMultimedia am 
                                            WHERE am.LangId = @langId AND am.FileType = 1 AND am.IsActive = 1 AND am.IsDeleted = 0 ORDER BY am.Id DESC;                       
                          SELECT TOP 3 am.* FROM dbo.tblArticleMultimedia am WHERE am.LangId = @langId AND am.FileType = 1 AND am.IsActive = 1 AND am.IsDeleted = 0 ORDER BY am.CntViews DESC;                         
                          SELECT TOP 6 at.* FROM tblArticleTrans at inner join tblArticle a on at.ArticleId = a.Id
                          WHERE at.LangId = @langId AND a.IsActive = 1 AND a.IsDeleted = 0 ORDER BY a.Id DESC;";

            var result = base.GetMultiple(query, false, new { @langId = langId }, 
                x => x.Read<ArticleMultimedia>(),
                x => x.Read<ArticleMultimedia>(),
                x => x.Read<ArticleTrans>());

            var topVideo = result.Item1 != null ? result.Item1.ToList() : new List<ArticleMultimedia>();
            var recentVideo = result.Item2 != null ? result.Item2.ToList() : new List<ArticleMultimedia>();
            var article = result.Item3 != null ? result.Item3.ToList() : new List<ArticleTrans>();
            return new MultimediaTopVideo()
            {
                TopVideo = topVideo.FirstOrDefault(),
                RecentVideo = recentVideo,
                Article = article
            };

        }

        public bool SetArticleMediaStatus(long mediaArticleId)
        {
            var isexist = this.GetArticleMultimediaById(mediaArticleId);
           isexist.IsMobile = isexist.IsMobile == true ? false : true;
            var result = base.Update(isexist);
            if (result > 0) return true;
            return false;
        }       

        public int UpdateArticleMultimedia(ArticleMultimedia articlemultimedia)
        {
            articlemultimedia.UpdatedOn = DateTime.Now;
            return base.Update(articlemultimedia);
        }        
    }
}
