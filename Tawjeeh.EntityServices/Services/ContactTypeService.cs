using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IContactTypeService" />
    public class ContactTypeService : IContactTypeService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactTypeService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public ContactTypeService(IRepositoryFactory repositoryFactory)
        {
            Guard.NotNull(repositoryFactory, nameof(repositoryFactory));
            _repositoryFactory = repositoryFactory;
        }
        /// <summary>
        /// Inserts the or update contact type service.
        /// </summary>
        /// <param name="contype">The contype.</param>
        /// <returns></returns>
        public int InsertOrUpdateContactTypeService(ContactType contype)
        {
            return _repositoryFactory.GetContactTypeRepository.InsertOrUpdateContactType(contype);
        }

        /// <summary>
        /// Deletes the specified contype.
        /// </summary>
        /// <param name="contype">The contype.</param>
        /// <returns></returns>
        public int Delete(ContactType contype)
        {
            return _repositoryFactory.GetContactTypeRepository.Delete(contype);
        }

        /// <summary>
        /// Gets the type of all contact.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ContactType>> GetAllContactType()
        {
            return _repositoryFactory.GetContactTypeRepository.GetAllContactType();
        }

        /// <summary>
        /// Gets the contact type by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ContactType GetContactTypeById(long id)
        {
            return _repositoryFactory.GetContactTypeRepository.GetContactTypeById(id);
        }

        /// <summary>
        /// Ges the name of the t contact type by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ContactType GeTContactTypeByName(string name)
        {
            return _repositoryFactory.GetContactTypeRepository.GeTContactTypeByName(name);
        }

       
    }
}
