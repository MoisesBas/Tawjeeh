using System;
using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public  interface IArticleMultimediaRepository
    {
        int CreateArticleMultimedia(ArticleMultimedia articlemultimedia);
        int DeleteArticleMultimedia(ArticleMultimedia articlemultimedia);
        int UpdateArticleMultimedia(ArticleMultimedia articlemultimedia);
        IList<ArticleMultimedia> GetArticleMultimediaAll();
        ArticleMultimedia GetArticleMultimediaById(long multimediaId);
        ArticleMultimedia GetArticleMultimediaLangIdAndId(long id,long articleId, int langId);
        IList<ArticleMultimedia> GetArticleMultimediaByArticleId(long articleId);
        IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId);
        IList<ArticleMultimedia> GetArticleMultimediaByArticleIdAndLangId(long articleId, int langId, long lawId);
        ArticleMultimedia GetArticleMultimediaByName(string name, Int64 articleId);
        MultimediaTopVideo GetMultimediaTopVideo();
        MultimediaTopVideo GetMultimediaTopVideoByLangId(int langId);
        //IList<ArticleMultimedia> GetArticleMultimedia(int langId);
        bool SetArticleMediaStatus(Int64 mediaArticleId);      
       

        #region

        #endregion
    }
}
