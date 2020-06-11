using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityServices.Interface
{
    public interface ICenterService
    {
        int InsertOrUpdateCenters(Centers center);
        int DeleteCenter(Centers center);
        int DeleteCenterTrans(CenterTrans centerTrans);
        IEnumerable<Centers> GetAll(int langId);
        IEnumerable<Centers> GetAll();
        Centers GetCenterById(long id);
        Centers GetCenterById(int id, int langId);
        int InsertOrUpdateCenterTrans(CenterTrans centerTrans);
        Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId);
        Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId, int langId);
    }
}
