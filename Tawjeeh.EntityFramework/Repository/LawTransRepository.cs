using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ILawTransRepository{Tawjeeh.EntityModel.LawTrans}" />
    public class LawTransRepository : RepositoryBase<TawjeehContext>,
          ILawTransRepository<LawTrans>
    {
        /// <summary>
        /// Deletes the law trans.
        /// </summary>
        /// <param name="lawtrans">The lawtrans.</param>
        /// <returns></returns>
        public int DeleteLawTrans(LawTrans lawtrans)
        {
            return DeleteRecord(lawtrans);
        }
        /// <summary>
        /// Gets the law trans.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public LawTrans GetLawTrans(long lawId, int langId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the law trans all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<LawTrans>> GetLawTransAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the law trans by law identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<LawTrans> GetLawTransByLawId(long lawId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the law trans identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public LawTrans GetLawTransId(long id)
        {
            var lawtrans = Query<LawTrans>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(lawtrans);
        }
        /// <summary>
        /// Gets the law trans identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public LawTrans GetLawTransId(long lawId, int langId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Inserts the or update law trans.
        /// </summary>
        /// <param name="lawtrans">The lawtrans.</param>
        /// <returns></returns>
        public int InsertOrUpdateLawTrans(LawTrans lawtrans)
        {
            return InsertOrUpdate(lawtrans);
        }       
    }
}
