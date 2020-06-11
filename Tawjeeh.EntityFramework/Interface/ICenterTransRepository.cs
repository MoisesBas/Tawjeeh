using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
  public  interface ICenterTransRepository<T> where T:class
    {
        int InsertOrUpdateCenterTrans(T center);
        int DeleteCenterTrans(T center);      
        Task<IEnumerable<T>> GetCenterTransAll();
        T GetCenterTransId(int id);
        T GetCenterTransId(Int64 centerId, int langId);
        IList<T> GetCenterTransByCenterId(Int64 centerId);
    }
}
