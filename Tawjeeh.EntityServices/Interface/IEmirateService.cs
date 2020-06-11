using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityServices.Interface
{
    public interface IEmirateService
    {
        
        int DeleteEmirates(Emirates emirates);       
        Task<IEnumerable<Emirates>> GetAll();
        Emirates GetEmiratesById(long id);
        int InsertOrUpdateEmirates(Emirates emirates);
    }
}
