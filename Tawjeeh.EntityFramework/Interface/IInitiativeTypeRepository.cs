using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
  public interface IInitiativeTypeRepository<T> where T: class
    {
        int InsertOrUpdateInitiativeType(T initiativeType);
        int DeleteInitiativeType(T initiativeType);        
        Task<IEnumerable<T>> GetAll();
        T GetInitiativeTypeById(int id);
    }
}
