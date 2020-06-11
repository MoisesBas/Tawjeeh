using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
  public interface ICountryRepository<T> where T: class
    {
        int InsertOrUpdateCountry(T country);
        int DeleteCountry(T country);      
        IEnumerable<T> GetAllCountry();
    }
}
