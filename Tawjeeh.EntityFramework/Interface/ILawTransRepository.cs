using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface ILawTransRepository<T> where T: class
    {
        int InsertOrUpdateLawTrans(T lawtrans);
        int DeleteLawTrans(T lawtrans);     
        Task<IEnumerable<T>> GetLawTransAll();
        T GetLawTransId(long id);
        T GetLawTransId(Int64 lawId, int langId);
        T GetLawTrans(Int64 lawId, int langId);
        IEnumerable<T> GetLawTransByLawId(Int64 lawId);
    }
}
