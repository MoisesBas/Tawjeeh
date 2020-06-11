using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
   public interface IEmirateService
    {
        int CreateEmirates(Emirates emirates);
        int DeleteEmirates(Emirates emirates);
        int UpdateEmirates(Emirates emirates);
        Task<IEnumerable<Emirates>> GetAll();
        Emirates GetEmiratesById(int id);
    }
}
