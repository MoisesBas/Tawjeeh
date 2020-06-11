using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
    public interface IUserService
    {
        int Create(User user);
        int Delete(User user);
        User GetUserById(int id);       
        int Update(User user);       
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserbyCredential(string userName, string password);
        User IsUserExist(string userName);       
        User IsUserExist(string userName, string mobileNo);
        int AddUserToCenter(User users);
        IEnumerable<User> GetAllUserByUserType(long userTypeId);
        User MobileRequestOTP(User user);
        User RegisterUser(User user);
        User ResendOTP(User user);
        User VerifyOTP(User user);
        User ResetPassword(User user);
        bool Login(string userName, string password);
    }
}
