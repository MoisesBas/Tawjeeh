using System;
using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IArticleRepository
    {
        int CreateArticle(Article article);
        int DeleteArticle(Article article);
        int UpdateArticle(Article article);
        IList<Article> GetArticleAll();
        Article GetArticleById(long id);
        Article GetArticleLangIdAndId(long id, int langId);
        IList<Article> GetArticleByLawId(long lawId);
        Article GetArticleByName(string name, Int64 lawId);
       
    }
}
