
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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IEmiratesRepository{Tawjeeh.EntityModel.Emirates}" />
    public class EmiratesRepository : RepositoryBase<TawjeehContext>,
        IEmiratesRepository<Emirates>
    {
        /// <summary>
        /// Inserts the or update emirates.
        /// </summary>
        /// <param name="emirates">The emirates.</param>
        /// <returns></returns>
        public int InsertOrUpdateEmirates(Emirates emirates)
        {
            return InsertOrUpdate(emirates);
        }
        /// <summary>
        /// Deletes the emirates.
        /// </summary>
        /// <param name="emirates">The emirates.</param>
        /// <returns></returns>
        public int DeleteEmirates(Emirates emirates)
        {
            return DeleteRecord(emirates);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Emirates>> GetAll()
        {
            return GetListDisposableContextAsync<Emirates>();
        }
        /// <summary>
        /// Gets the emirates by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Emirates GetEmiratesById(long id)
        {
            var search = Query<Emirates>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(search);
        }

    }
}
