using System;
using System.Collections.Generic;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface IArticleMultimediaRepository<T> where T: class
    {
        int InsertOrUpdateMultimedia(T articlemultimedia);       
        int DeleteArticleMultimedia(T articlemultimedia);       
        IEnumerable<T> GetArticleMultimediaByArticleId(long articleId);
        Tuple<IEnumerable<T>> GetArticleMultimediaByArticleIds(long[] articleIds);
        T GetArticleMultimediaByid(long Id);
       
    }
}
