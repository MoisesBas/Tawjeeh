using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface IArticleTransRepository<T> where T: class
    {

        int InsertUpdateArticleTrans(T article);
        int DeleteArticleTrans(T article);       
        Task<IEnumerable<T>> GetArticleAllTrans();
        T GetArticleTransById(long id);       
        T GetArticleLangIdAndArticleId(long articleId, int langId);        
        IEnumerable<T> GetArticleByLawIdAndLangId(long lawId, int langId);
        IEnumerable<T> GetArticleByLangId(int langId);
        IEnumerable<T> GetMultimediaTopVideo(int langId);
    }
}
