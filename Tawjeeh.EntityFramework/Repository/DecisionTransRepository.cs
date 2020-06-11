using System.Collections.Generic;
using System.Linq;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IDecisionTransRepository{Tawjeeh.EntityModel.DecisionTrans}" />
    public class DecisionTransRepository : RepositoryBase<TawjeehContext>,
         IDecisionTransRepository<DecisionTrans>
    {
        /// <summary>
        /// Getdecisions the trans language identifier and decision identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public IEnumerable<DecisionTrans> GetdecisionTransLangIdAndDecisionId(long decisionId, int langId)
        {
            var search = Query<DecisionTrans>.Create(x=>x.DecisionId == decisionId && x.LangId == langId);          
            return GetAllQueryDisposable(search, @"Decision,
                                                   Decision.MultimediaDecisions").AsEnumerable();
        }
        /// <summary>
        /// Inserts the or update decision trans.
        /// </summary>
        /// <param name="decisionTrans">The decision trans.</param>
        /// <returns></returns>
        public int InsertOrUpdateDecisionTrans(DecisionTrans decisionTrans)
        {
            return InsertOrUpdate(decisionTrans);
        }
    }
}
