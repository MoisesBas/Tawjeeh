using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ICenterTransRepository{Tawjeeh.EntityModel.CenterTrans}" />
    public class CenterTransRepository : RepositoryBase<TawjeehContext>, 
        ICenterTransRepository<CenterTrans>
    {
        /// <summary>
        /// Inserts the or update center trans.
        /// </summary>
        /// <param name="centerTrans">The center trans.</param>
        /// <returns></returns>
        public int InsertOrUpdateCenterTrans(CenterTrans centerTrans) => InsertOrUpdate(centerTrans);
        /// <summary>
        /// Deletes the center trans.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        public int DeleteCenterTrans(CenterTrans center) => DeleteRecord(center);
        /// <summary>
        /// Gets the center trans all.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CenterTrans>> GetCenterTransAll() => GetListDisposableContextAsync<CenterTrans>();
        /// <summary>
        /// Gets the center trans by center identifier.
        /// </summary>
        /// <param name="centerId">The center identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<CenterTrans> GetCenterTransByCenterId(long centerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the center trans identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CenterTrans GetCenterTransId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the center trans identifier.
        /// </summary>
        /// <param name="centerId">The center identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CenterTrans GetCenterTransId(long centerId, int langId)
        {
            throw new NotImplementedException();
        }

       
    }
}
