using System;
using System.Collections.Generic;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IArticleRepository<T> where T : class
    {
        int InsertUpdateArticle(T article);
        int DeleteArticle(T article);
        IEnumerable<T> GetArticleAll();
        IEnumerable<T> GetArticleAll(long[] articleIds);
        T GetArticleById(long id);
        IEnumerable<T> GetArticleByLawId(long lawId);
    }
}
