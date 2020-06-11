using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface ICenterRepository<T> where T : class
    {
       
        int DeleteCenter(T center);
        int InsertOrUpdateCenters(T center);      
        IEnumerable<T> GetAll();
        T GetCenterById(long id);       
        Task<IEnumerable<T>> GetAllCentersByEmiratesId(long emiratesId);       
    }
}
