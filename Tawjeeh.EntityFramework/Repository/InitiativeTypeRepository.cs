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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IInitiativeTypeRepository{Tawjeeh.EntityModel.InitiativeType}" />
    public class InitiativeTypeRepository : RepositoryBase<TawjeehContext>,
           IInitiativeTypeRepository<InitiativeType>
    {
        /// <summary>
        /// Deletes the type of the initiative.
        /// </summary>
        /// <param name="initiativeType">Type of the initiative.</param>
        /// <returns></returns>
        public int DeleteInitiativeType(InitiativeType initiativeType)
        {
            return DeleteRecord(initiativeType);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<InitiativeType>> GetAll()
        {
            return GetListDisposableContextAsync<InitiativeType>();
        }

        /// <summary>
        /// Gets the initiative type by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public InitiativeType GetInitiativeTypeById(int id)
        {
            var search = Query<InitiativeType>.Create(x => x.Id == id);
            return FirstOrDefaultDisposable(search);
        }

        /// <summary>
        /// Inserts the type of the or update initiative.
        /// </summary>
        /// <param name="initiativeType">Type of the initiative.</param>
        /// <returns></returns>
        public int InsertOrUpdateInitiativeType(InitiativeType initiativeType)
        {
            return InsertOrUpdate(initiativeType);
        }
    }
}
