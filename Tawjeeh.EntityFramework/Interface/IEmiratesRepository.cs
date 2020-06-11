using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface IEmiratesRepository<T> where T :class
    {
        int InsertOrUpdateEmirates(T emirates);
        int DeleteEmirates(T emirates);
       
        Task<IEnumerable<T>> GetAll();
        T GetEmiratesById(long id);
    }
}
