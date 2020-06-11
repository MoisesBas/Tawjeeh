using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IContactRepository{Tawjeeh.EntityModel.CenterContacts}" />
    public class CenterContactRepository : RepositoryBase<TawjeehContext>,
         IContactRepository<CenterContacts>
    {

        /// <summary>
        /// Gets the contacts by user ids.
        /// </summary>
        /// <param name="userIds">The user ids.</param>
        /// <returns></returns>
        public IReadOnlyList<CenterContacts> GetContactsByUserIds(long[] userIds)
        {
            var contactSearch = Query<CenterContacts>.Create(x => userIds.DefaultIfEmpty().Contains((x.UserId ?? 0)));
            return GetAllQueryDisposable(contactSearch, "Centers,ContactType").ToList();           
        }
    }
}
