using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IUserRepository<T> where T :class
    {
     
        int Delete(T user);
        int InsertOrUpdateUser(T user);       
        Task<IEnumerable<T>> GetAllUser();
        IEnumerable<T> GetUserByUserId(long[] userId);
        T GetUserById(long id);
        Task<T> GetUserbyCredential(string userName, string password);
        T IsUserExist(string userName);
        T IsMobileUser(string userName);
        T IsUserExist(string userName, string mobileNo);
        IEnumerable<T> GetAllUserByUserType(long? userTypeId);
        int RegisterUser(T user);
        bool Login(string userName, string password);
        T MobileLogin(string userName, string password);
      

    }
}
