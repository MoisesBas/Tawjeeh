using log4net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class ArticleService : IArticleService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ArticleService));
        private IArticleRepository _articleRepo;
        private IArticleTransRepository _transRepository;
        private IArticleMultimediaRepository _articleMultimedia;
        public ArticleService(IArticleRepository articleRepo,
                              IArticleTransRepository transRepository,
                              IArticleMultimediaRepository articleMultimediaRepository)
        {
            Guard.NotNull(articleRepo, nameof(articleRepo));
            Guard.NotNull(transRepository, nameof(transRepository));
            Guard.NotNull(articleMultimediaRepository, nameof(articleMultimediaRepository));

            _articleRepo = articleRepo;
            _transRepository = transRepository;
            _articleMultimedia = articleMultimediaRepository;
        }

        public int CreateArticle(Article article)
        {
            var isexists = _articleRepo.GetArticleByName(article.Name, Convert.ToInt64(article.LawId));

            if (isexists != null)
                throw new Exception("Article is already exists.,");

            return _articleRepo.CreateArticle(article);
        }
        public int CreateArticleTrans(ArticleTrans article)
        {
            var isexists = _transRepository.GetArticleTransLangIdAndId(Convert.ToInt64(article.ArticleId), Convert.ToInt32(article.LangId));
            if (isexists != null)
                throw new Exception("Article Translation is Already Exists.,");
            return _transRepository.CreateArticleTrans(article);
        }
        public int DeleteArticle(Article article)
        {
            return _articleRepo.DeleteArticle(article);
        }
        public int DeleteArticleTrans(ArticleTrans article)
        {
            return _transRepository.DeleteArticleTrans(article);
        }
        public IList<Article> GetArticleAll()
        {
            return _articleRepo.GetArticleAll();
        }
        public Task<IEnumerable<ArticleTrans>> GetArticleAllTrans()
        {
            return _transRepository.GetArticleAllTrans();
        }
        public Article GetArticleById(int id)
        {
            return _articleRepo.GetArticleById(id);
        }
        public IList<Article> GetArticleByLawId(long lawId)
        {
            return _articleRepo.GetArticleByLawId(lawId);
        }
        public Article GetArticleLangIdAndId(long id, int langId)
        {
            return _articleRepo.GetArticleLangIdAndId(id, langId);
        }
        public ArticleTrans GetArticleTransById(int id)
        {
            return _transRepository.GetArticleTransById(id);
        }
        public ArticleTrans GetArticleTransLangIdAndId(long id, int langId)
        {
            return _transRepository.GetArticleTransLangIdAndId(id, langId);
        }
        public ArticleTrans GetArticleLangIdAndArticleId(long articleId, int langId)
        {
            return _transRepository.GetArticleLangIdAndArticleId(articleId, langId);
        }

        public int UpdateArticle(Article article)
        {
            return _articleRepo.UpdateArticle(article);
        }
        public int UpdateArticleTrans(ArticleTrans article)
        {
            return _transRepository.UpdateArticleTrans(article);
        }

        public int CreateArticleMultimedia(ArticleMultimedia articlemultimedia)
        {
            return _articleMultimedia.CreateArticleMultimedia(articlemultimedia);
        }
        public int DeleteArticleMultimedia(ArticleMultimedia articlemultimedia)
        {
            return _articleMultimedia.DeleteArticleMultimedia(articlemultimedia);
        }
        public int UpdateArticleMultimedia(ArticleMultimedia articlemultimedia)
        {
            return _articleMultimedia.UpdateArticleMultimedia(articlemultimedia);
        }
        public IList<ArticleMultimedia> GetArticleMultimediaAll()
        {
            return _articleMultimedia.GetArticleMultimediaAll();
        }
        public ArticleMultimedia GetArticleMultimediaById(long multimediaId)
        {
            return _articleMultimedia.GetArticleMultimediaById(multimediaId);
        }
        public ArticleMultimedia GetArticleMultimediaLangIdAndId(long id, long articleId, int langId)
        {
            return _articleMultimedia.GetArticleMultimediaLangIdAndId(id, articleId, langId);
        }
        public IList<ArticleMultimedia> GetArticleMultimediaByArticleId(long articleId)
        {
            return _articleMultimedia.GetArticleMultimediaByArticleId(articleId);
        }
        public IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId)
        {
            return _articleMultimedia.GetArticleMultimediaByArticleIdAndLangId(articleId, langId);
        }
        public ArticleMultimedia GetArticleMultimediaByName(string name, Int64 articleId)
        {
            return _articleMultimedia.GetArticleMultimediaByName(name, articleId);
        }
        public bool SetArticleMediaStatus(long mediaArticleId)
        {
            return _articleMultimedia.SetArticleMediaStatus(mediaArticleId);
        }

        public IList<ArticleTrans> GetArticleByLawIdAndLangId(long lawId, int langId)
        {
            return _transRepository.GetArticleByLawIdAndLangId(lawId, langId);
        }
        public IList<ArticleTrans> GetArticleByLangId(int langId)
        {
            return _transRepository.GetArticleByLangId(langId);
        }

        public IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId, long lawId)
        {
            return _articleMultimedia.GetArticleMultimediaByArticleIdAndLangId(articleId, langId, lawId);
        }

        public MultimediaTopVideo GetMultimediaTopVideo()
        {
            return _articleMultimedia.GetMultimediaTopVideo();
        }

        public int SetLike(long media)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                var result = _articleMultimedia.GetArticleMultimediaById(media);
                Guard.NotNull(result, "Multimedia Article is NULL");
                result.CntLikes = result.CntLikes + 1;
                output = _articleMultimedia.UpdateArticleMultimedia(result);
            }, "SetLike(long media)", log);
            return output;
        }

        public int SetViewMultimedia(long media)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                var result = _articleMultimedia.GetArticleMultimediaById(media);
                Guard.NotNull(result, "Multimedia Article is NULL");
                result.CntViews = result.CntViews + 1;
                output = _articleMultimedia.UpdateArticleMultimedia(result);
            }, "SetViewMultimedia(long media)", log);
            return output;
        }

        public int SetDisLike(long media)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                var result = _articleMultimedia.GetArticleMultimediaById(media);
                Guard.NotNull(result, "Multimedia Article is NULL");
                result.CntDisLikes = result.CntDisLikes + 1;
                output = _articleMultimedia.UpdateArticleMultimedia(result);
            }, "SetDisLike(long media)", log);
            return output;
        }

        public MultimediaTopVideo GetMultimediaTopVideoByLangId(int langId)
        {
            return _articleMultimedia.GetMultimediaTopVideoByLangId(langId);
        }
    }
}
