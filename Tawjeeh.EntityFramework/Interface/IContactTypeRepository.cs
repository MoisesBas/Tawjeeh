using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface IContactTypeRepository<T> where T: class
    {

        int InsertOrUpdateContactType(T contype);
        int Delete(T contype);        
        Task<IEnumerable<T>> GetAllContactType();
        T GetContactTypeById(long id);
        T GeTContactTypeByName(string name);
    }
}
