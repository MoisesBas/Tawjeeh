using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
   public interface ICenterTransRepository
    {
        int CreateCenterTrans(CenterTrans centerTrans);
        int DeleteCenterTrans(CenterTrans center);
        int UpdateCenterTrans(CenterTrans center);
        Task<IEnumerable<CenterTrans>> GetCenterTransAll();
        CenterTrans GetCenterTransId(int id);
        CenterTrans GetCenterTransId(Int64 centerId, int langId);
        IList<CenterTrans> GetCenterTransByCenterId(Int64 centerId);
    }
}
