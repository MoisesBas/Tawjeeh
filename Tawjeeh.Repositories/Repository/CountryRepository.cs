using System;
using System.Collections.Generic;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class CountryRepository : BaseRepository<Country>,
         ICountryRepository
    {
        public CountryRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateCountry(Country country)
        {
            return base.Create(country);
        }

        public int DeleteCountry(Country country)
        {
            country.IsActive = true;
            country.IsDeleted = false;
            country.UpdatedOn = DateTime.Now;

            return base.Update(country);
        }

        public IList<Country> GetAllCountry()
        {
            return base.GetAll();
        }

        public int UpdateCountry(Country country)
        {
            return base.Update(country);
        }
    }
}
