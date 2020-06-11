using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IUserTypeRepository<T> where T: class
    {
        int CreateUserType(T userType);
        int DeleteUserType(T userType);
        int UpdateUserType(T userType);
        Task<IEnumerable<T>> GetAll();
        T GetUserTypeById(int id);
    }
}
