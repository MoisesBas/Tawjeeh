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
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IEmirateService" />
    public class EmirateService : IEmirateService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmirateService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public EmirateService(IRepositoryFactory repositoryFactory)
        {
            Guard.NotNull(repositoryFactory, nameof(repositoryFactory));
            _repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Deletes the emirates.
        /// </summary>
        /// <param name="emirates">The emirates.</param>
        /// <returns></returns>
        public int DeleteEmirates(Emirates emirates)
        {
            var result = _repositoryFactory.GetEmiratesRepository.GetEmiratesById(emirates.Id);
            return _repositoryFactory.GetEmiratesRepository.DeleteEmirates(result);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Emirates>> GetAll()
        {
            return _repositoryFactory.GetEmiratesRepository.GetAll();
        }

        /// <summary>
        /// Gets the emirates by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Emirates GetEmiratesById(long id)
        {
            return _repositoryFactory.GetEmiratesRepository.GetEmiratesById(id);
        }

        /// <summary>
        /// Inserts the or update emirates.
        /// </summary>
        /// <param name="emirates">The emirates.</param>
        /// <returns></returns>
        public int InsertOrUpdateEmirates(Emirates emirates)
        {
            return _repositoryFactory.GetEmiratesRepository.InsertOrUpdateEmirates(emirates);
            
        }
    }
}
