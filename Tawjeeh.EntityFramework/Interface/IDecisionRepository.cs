using System;
using System.Collections.Generic;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IDecisionRepository<T> where T: class
    {
       
        int DeleteDecision(T decision);
        int InsertOrUpdateDecision(T decision);
        IEnumerable<T> GetDecisionAll();
        Tuple<IEnumerable<T>> GetDecisionAll(long[] articleIds);
        IEnumerable<T> GetDecisionByArticleIdAndLangId(long articleId);
        T GetDecisionById(long id);
        IEnumerable<T> GetDecisionAlls();


    }
}
