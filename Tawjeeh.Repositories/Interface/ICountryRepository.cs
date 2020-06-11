using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface  ICountryRepository
    {
        int CreateCountry(Country country);
        int DeleteCountry(Country country);
        int UpdateCountry(Country country);
        IList<Country> GetAllCountry();
    }
}
