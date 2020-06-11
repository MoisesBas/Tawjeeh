using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityServices.Interface
{
   public interface IUtilityService
    {
        IEnumerable<Country> GetAllCountry();
        int InsetOrUpdateCountry(Country country);
        Task<IEnumerable<InitiativeType>> GetInitiativeTypeAll();
        IEnumerable<MultimediaType> GetAllMultimediaType();
    }
}
