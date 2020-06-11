using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
   public interface ICenterService
    {
        int CreateCenter(Centers center);
        int DeleteCenter(Centers center);
        int UpdateCenter(Centers center);
        IEnumerable<Centers> GetAll(int langId);
        IEnumerable<Centers> GetAll();
        Centers GetCenterById(int id);
        Centers GetCenterById(int id, int langId);
        Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId);
        Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId, int langId);

        //Center Trans
        int CreateCenterTrans(CenterTrans centerTrans);
        int DeleteCenterTrans(CenterTrans center);
        int UpdateCenterTrans(CenterTrans center);
        Task<IEnumerable<CenterTrans>> GetCenterTransAll();
        CenterTrans GetCenterTransId(int id);
     

    }
}
