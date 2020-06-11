using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ICenterRepository{Tawjeeh.EntityModel.Centers}" />
    public class CenterRepository : RepositoryBase<TawjeehContext>, 
        ICenterRepository<Centers>
    {
        /// <summary>
        /// Deletes the center.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        public int DeleteCenter(Centers center)
        {
            return DeleteRecord(center);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Centers> GetAll()
        {           
           return GetAllIncludeQuery<Centers>(@"Emirates,
                                                Contacts,
                                                Contacts.User,
                                                CenterTrans,
                                                Contacts.ContactType")
                                                .AsNoTracking()
                                                .AsEnumerable();           
        }
        /// <summary>
        /// Gets all centers by emirates identifier.
        /// </summary>
        /// <param name="emiratesId">The emirates identifier.</param>
        /// <returns></returns>
        public Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(long emiratesId)
        {
           var filter =  Query<Centers>.Create(x => x.EmiratesId == emiratesId);
            return GetAllQueryDisposableAsync(filter,@"Emirates,
                                                Contacts,
                                                Contacts.User,
                                                CenterTrans,
                                                Contacts.ContactType");
        }
        /// <summary>
        /// Gets the center by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Centers GetCenterById(long id)
        {
            var filter = Query<Centers>.Create(x => x.Id == id);
            return FirstOrDefaultDisposable(filter, @"Emirates,
                                                Contacts,
                                                Contacts.User,
                                                CenterTrans,
                                                Contacts.ContactType");
        }
        /// <summary>
        /// Inserts the or update centers.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        public int InsertOrUpdateCenters(Centers center)
        {
            return InsertOrUpdate(center);
        }
    }
}
