
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;

namespace Tawjeeh.EntityServices.Interface
{
   public interface IArticleService
    {
        int InsertUpdateArticle(Article article);
        int DeleteArticle(Article article);     
        IEnumerable<Article> GetArticleAll();
        IEnumerable<Article> GetArticleByLawId(long lawId);
        Article GetArticleById(int id);
        Article GetArticleLangIdAndId(long id, int langId);       
        int DeleteArticleTrans(ArticleTrans article);       
        ArticleTrans GetArticleLangIdAndArticleId(long articleId, int langId);     
        IEnumerable<ArticleTransReadOnly> GetArticleByLangId(int langId);      
        IEnumerable<ArticleMultimedia> GetArticleMultimediaByArticleId(long articleId);       
        MultimediaTopVideoReadOnly GetMultimediaTopVideoByLangId(int langId);
        bool SetArticleMediaStatus(long mediaArticleId);
        int SetLike(Int64 media);
        int SetViewMultimedia(Int64 media);
        int SetDisLike(Int64 media);
        int InsertUpdateArticleTrans(ArticleTrans map);
        int InsertOrUpdateArticleMultimedia(ArticleMultimedia articleMultimedia);
        int DeleteArticleMultimedia(ArticleMultimedia articleMultimedia);
    }
}
