using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
    public interface IArticleService
    {
        int CreateArticle(Article article);
        int DeleteArticle(Article article);
        int UpdateArticle(Article article);
        IList<Article> GetArticleAll();
        IList<Article> GetArticleByLawId(long lawId);
       
        Article GetArticleById(int id);
        Article GetArticleLangIdAndId(long id, int langId);
        int CreateArticleTrans(ArticleTrans article);
        int DeleteArticleTrans(ArticleTrans article);
        int UpdateArticleTrans(ArticleTrans article);
        Task<IEnumerable<ArticleTrans>> GetArticleAllTrans();
        ArticleTrans GetArticleTransById(int id);
        ArticleTrans GetArticleTransLangIdAndId(long id, int langId);
        ArticleTrans GetArticleLangIdAndArticleId(long articleId, int langId);
        IList<ArticleTrans> GetArticleByLawIdAndLangId(long lawId, int langId);
        IList<ArticleTrans> GetArticleByLangId(int langId);
        int CreateArticleMultimedia(ArticleMultimedia articlemultimedia);
        int DeleteArticleMultimedia(ArticleMultimedia articlemultimedia);
        int UpdateArticleMultimedia(ArticleMultimedia articlemultimedia);
        IList<ArticleMultimedia> GetArticleMultimediaAll();
        ArticleMultimedia GetArticleMultimediaById(long multimediaId);
        ArticleMultimedia GetArticleMultimediaLangIdAndId(long id, long articleId, int langId);
        IList<ArticleMultimedia> GetArticleMultimediaByArticleId(long articleId);
        IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId);
        IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId, long lawId);
        ArticleMultimedia GetArticleMultimediaByName(string name, Int64 articleId);
        MultimediaTopVideo GetMultimediaTopVideo();
        MultimediaTopVideo GetMultimediaTopVideoByLangId(int langId);
        bool SetArticleMediaStatus(long mediaArticleId);
        int SetLike(Int64 media);
        int SetViewMultimedia(Int64 media);
        int SetDisLike(Int64 media);

    }
}
