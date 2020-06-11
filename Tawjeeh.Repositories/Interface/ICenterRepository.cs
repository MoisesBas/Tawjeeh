using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface ICenterRepository
    {
        int CreateCenter(Centers center);
        int DeleteCenter(Centers center);
        int UpdateCenter(Centers center);
        IEnumerable<Centers> GetAll(int langId);
        IList<Centers> GetAll();
        Centers GetCenterById(int id);
        Centers GetCenterByName(string centerName, Int64 emiratesId);
        Centers GetCenterById(int id, int langId);
        Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId);
        Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId, int langId);
               

    }
}
