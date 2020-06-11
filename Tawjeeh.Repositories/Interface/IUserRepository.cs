using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IUserRepository
    {
        int Create(User user);
        int Delete(User user);
        int Update(User user);
        Task<IEnumerable<User>> GetAllUser();               
        User GetUserById(int id);
        Task<User> GetUserbyCredential(string userName, string password);
        User IsUserExist(string userName);       
        User IsUserExist(string userName, string mobileNo);
        IEnumerable<User> GetAllUserByUserType(long userTypeId);
        int RegisterUser(User user);
        bool Login(string userName, string password);



    }
}
