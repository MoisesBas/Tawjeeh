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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IDecisionMultimediaRepository{Tawjeeh.EntityModel.DecisionMultimedia}" />
    public class DecisionMultimediaRepository : RepositoryBase<TawjeehContext>,
   IDecisionMultimediaRepository<DecisionMultimedia>
    {
        /// <summary>
        /// Gets the decision multimedia by decision multimedia identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <returns></returns>
        public IEnumerable<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaId(long decisionId)
        {
            var search = Query<DecisionMultimedia>.Create("DecisionId", OperationType.EqualTo, decisionId);
            return GetAllQuery(search).AsEnumerable();
        }
        /// <summary>
        /// Gets the decision multimedia by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public DecisionMultimedia GetDecisionMultimediaById(long id)
        {
            var search = Query<DecisionMultimedia>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(search);
        }

        /// <summary>
        /// Inserts the or update decision multimedia.
        /// </summary>
        /// <param name="decisionMultimedia">The decision multimedia.</param>
        /// <returns></returns>
        public int InsertOrUpdateDecisionMultimedia(DecisionMultimedia decisionMultimedia)
        {
            return InsertOrUpdate(decisionMultimedia);
        }
    }
}
