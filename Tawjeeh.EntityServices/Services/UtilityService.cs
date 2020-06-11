using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;

namespace Tawjeeh.EntityServices.Services
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IUtilityService" />
    public class UtilityService : IUtilityService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public UtilityService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        /// <summary>
        /// Gets all country.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Country> GetAllCountry()
        {
            return _repositoryFactory.GetCountryRepository.GetAllCountry();
        }

        /// <summary>
        /// Gets the type of all multimedia.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MultimediaType> GetAllMultimediaType()
        {
            return _repositoryFactory.GetMultimediaTypeRepository.GetAllMultimediaType();
        }

        /// <summary>
        /// Gets the initiative type all.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<InitiativeType>> GetInitiativeTypeAll()
        {
            return _repositoryFactory.GetInitiativeTypeRepository.GetAll();
        }

        /// <summary>
        /// Insets the or update country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        public int InsetOrUpdateCountry(Country country)
        {
            return _repositoryFactory.GetCountryRepository.InsertOrUpdateCountry(country);
        }
    }
}
