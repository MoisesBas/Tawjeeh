using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;
using Tawjeeh.EntityServices.Interface;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IArticleService" />
    public class ArticleService : IArticleService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public ArticleService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        /// <summary>
        /// Inserts the update article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public int InsertUpdateArticle(Article article)
        {
            return _repositoryFactory.GetArticleRepository.InsertUpdateArticle(article);
        }
        /// <summary>
        /// Deletes the article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public int DeleteArticle(Article article)
        {
            var result = _repositoryFactory.GetArticleRepository.GetArticleById(article.Id);
            return _repositoryFactory.GetArticleRepository.DeleteArticle(result);
        }
        /// <summary>
        /// Gets the article all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> GetArticleAll()
        {
            return _repositoryFactory.GetArticleRepository.GetArticleAll();            
        }
        /// <summary>
        /// Gets the article by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Article GetArticleById(int id)
        {
            return _repositoryFactory.GetArticleRepository.GetArticleById(id);
        }
        /// <summary>
        /// Gets the article by law identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticleByLawId(long lawId)
        {
            return _repositoryFactory.GetArticleRepository.GetArticleByLawId(lawId);
        }
        /// <summary>
        /// Gets the article language identifier and article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public ArticleTrans GetArticleLangIdAndArticleId(long articleId, int langId)
        {
            return _repositoryFactory.GetArticleTransRepository.GetArticleLangIdAndArticleId(articleId, langId);
        }
        /// <summary>
        /// Gets the article language identifier and identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Article GetArticleLangIdAndId(long id, int langId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the article media status.
        /// </summary>
        /// <param name="mediaArticleId">The media article identifier.</param>
        /// <returns></returns>
        public bool SetArticleMediaStatus(long mediaArticleId)
        {
            var result = _repositoryFactory.GetArticleMultimediaRepository.GetArticleMultimediaByid(mediaArticleId);
            result.IsMobile = result?.IsMobile == true ? false : true;
            var output = _repositoryFactory.GetArticleMultimediaRepository.InsertOrUpdateMultimedia(result);
            if (output > 0) return true;
            return false;
        }
        /// <summary>
        /// Sets the dis like.
        /// </summary>
        /// <param name="media">The media.</param>
        /// <returns></returns>
        public int SetDisLike(long media)
        {
            var result = _repositoryFactory.GetArticleMultimediaRepository.GetArticleMultimediaByid(media);
            result.CntDisLikes = result.CntDisLikes + 1;
            var output = _repositoryFactory.GetArticleMultimediaRepository.InsertOrUpdateMultimedia(result);
            return output;
        }
        /// <summary>
        /// Sets the like.
        /// </summary>
        /// <param name="media">The media.</param>
        /// <returns></returns>
        public int SetLike(long media)
        {
            var result = _repositoryFactory.GetArticleMultimediaRepository.GetArticleMultimediaByid(media);
            result.CntLikes = result.CntLikes + 1;
            var output = _repositoryFactory.GetArticleMultimediaRepository.InsertOrUpdateMultimedia(result);
            return output;
        }
        /// <summary>
        /// Sets the view multimedia.
        /// </summary>
        /// <param name="media">The media.</param>
        /// <returns></returns>
        public int SetViewMultimedia(long media)
        {
            var result = _repositoryFactory.GetArticleMultimediaRepository.GetArticleMultimediaByid(media);
            result.CntViews = result.CntViews + 1;
            var output = _repositoryFactory.GetArticleMultimediaRepository.InsertOrUpdateMultimedia(result);
            return output;
        }
        /// <summary>
        /// Gets the article by language identifier.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public IEnumerable<ArticleTransReadOnly> GetArticleByLangId(int langId)
        {
            var result = _repositoryFactory.GetArticleTransRepository.GetArticleByLangId(langId);
            var output = (from r in result
                          select new ArticleTransReadOnly
                          {
                              Id = r.Id,
                              Name = r.Name,
                              Description = r.Description,
                              ArticleId = r.ArticleId,
                              ArticleNo = r.ArticleNo,
                              LangId = r.LangId,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                              CreatedBy = r.CreatedBy,
                              CreatedOn = r.CreatedOn,
                              UpdatedBy = r.UpdatedBy,
                              UpdatedOn = r.UpdatedOn,
                              ArticleMultimedia = r?.Article?.MultimediaArticles.DefaultIfEmpty(),
                              DecisionTrans = r?.Article?.Decisions?.SelectMany(x => x.DecisionTranslations.Where(y => y.LangId == langId)).DefaultIfEmpty(),
                              DecisionMultimedia = r?.Article?.Decisions?.SelectMany(x => x.MultimediaDecisions).DefaultIfEmpty()
                          }).AsEnumerable();

            return output ?? output;
        }
        /// <summary>
        /// Gets the multimedia top video by language identifier.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public MultimediaTopVideoReadOnly GetMultimediaTopVideoByLangId(int langId)
        {
            var result = _repositoryFactory.GetArticleTransRepository.GetMultimediaTopVideo(langId).DefaultIfEmpty(new ArticleTrans());
            var output = GetTopVideo(result);
            return new MultimediaTopVideoReadOnly()
            {
                TopVideo = output.Count > 0 ? output?.Last() : null,
                RecentVideo = output.Count > 0 ? output?.Take(3) : null,
                Article = result.Count() > 0 ? result?.Where(x => x.CreatedOn.HasValue)
                                 .OrderByDescending(x => x.CreatedOn.Value).Take(6) : null
            };

        }
        /// <summary>
        /// Gets the top video.
        /// </summary>
        /// <param name="articleTrans">The article trans.</param>
        /// <returns></returns>
        static List<ArticleMultimedia> GetTopVideo(IEnumerable<ArticleTrans> articleTrans)
        {
            var result = (from n in articleTrans
                          let a = n.Article
                          where a != null
                          let m = a.MultimediaArticles
                          where m != null
                          select m.AsEnumerable())
                          .SelectMany(x => x.Where(y => y.CreatedOn.HasValue)
                          .OrderByDescending(y => y.CreatedOn)).ToList();

            return result;

        }
        /// <summary>
        /// Inserts the update article trans.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public int InsertUpdateArticleTrans(ArticleTrans map)
        {
            return _repositoryFactory.GetArticleTransRepository.InsertUpdateArticleTrans(map);
        }
        /// <summary>
        /// Deletes the article trans.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public int DeleteArticleTrans(ArticleTrans article)
        {
            var result = _repositoryFactory.GetArticleTransRepository.GetArticleTransById(article.Id);
            return _repositoryFactory.GetArticleTransRepository.DeleteArticleTrans(result);
        }
        /// <summary>
        /// Inserts the or update article multimedia.
        /// </summary>
        /// <param name="articleMultimedia">The article multimedia.</param>
        /// <returns></returns>
        public int InsertOrUpdateArticleMultimedia(ArticleMultimedia articleMultimedia)
        {
            return _repositoryFactory.GetArticleMultimediaRepository.InsertOrUpdateMultimedia(articleMultimedia);
        }
        /// <summary>
        /// Deletes the article multimedia.
        /// </summary>
        /// <param name="articleMultimedia">The article multimedia.</param>
        /// <returns></returns>
        public int DeleteArticleMultimedia(ArticleMultimedia articleMultimedia)
        {
            var result = _repositoryFactory.GetArticleMultimediaRepository.GetArticleMultimediaByid(articleMultimedia.Id);
            return _repositoryFactory.GetArticleMultimediaRepository.DeleteArticleMultimedia(result);
        }
        /// <summary>
        /// Gets the article multimedia by article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public IEnumerable<ArticleMultimedia> GetArticleMultimediaByArticleId(long articleId)
        {
            return _repositoryFactory.GetArticleMultimediaRepository.GetArticleMultimediaByArticleId(articleId);
        }
    }
}

