using System;
using System.Collections.Generic;
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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IContactTypeRepository{Tawjeeh.EntityModel.ContactType}" />
    public class ContactTypeRepository : RepositoryBase<TawjeehContext>,
        IContactTypeRepository<ContactType>
    {
        /// <summary>
        /// Inserts the type of the or update contact.
        /// </summary>
        /// <param name="contype">The contype.</param>
        /// <returns></returns>
        public int InsertOrUpdateContactType(ContactType contype) => InsertOrUpdate(contype);
        /// <summary>
        /// Deletes the specified contype.
        /// </summary>
        /// <param name="contype">The contype.</param>
        /// <returns></returns>
        public int Delete(ContactType contype) => DeleteRecord(contype);
        /// <summary>
        /// Gets the type of all contact.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ContactType>> GetAllContactType() => GetListDisposableContextAsync<ContactType>();
        /// <summary>
        /// Gets the contact type by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ContactType GetContactTypeById(long id) => GetById<ContactType>(id);
        /// <summary>
        /// Ges the name of the t contact type by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ContactType GeTContactTypeByName(string name)
        {           
            var filter = Query<ContactType>.Create(x => x.Name == name 
                                            && x.IsDeleted == false);
            return GetAllQuery(filter).FirstOrDefault();           
        }       
    }
}
