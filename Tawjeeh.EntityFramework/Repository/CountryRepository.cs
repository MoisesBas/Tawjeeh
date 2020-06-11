using System.Collections.Generic;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ICountryRepository{Tawjeeh.EntityModel.Country}" />
    public class CountryRepository : RepositoryBase<TawjeehContext>,
         ICountryRepository<Country>
    {
        /// <summary>
        /// Deletes the country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        public int DeleteCountry(Country country)
        {
            return DeleteRecord(country);
        }
        /// <summary>
        /// Gets all country.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Country> GetAllCountry()
        {
            return GetListDisposableContext<Country>();
        }
        /// <summary>
        /// Inserts the or update country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        public int InsertOrUpdateCountry(Country country)
        {
            return InsertOrUpdate(country);
        }
    }
}
