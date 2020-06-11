using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class UserTypeRepository : BaseRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
        public int CreateUserType(UserType userType)
        {
            return Create(userType);
        }
        public int DeleteUserType(UserType userType)
        {
            return Delete(userType);
        }
        public Task<IEnumerable<UserType>> GetAll()
        {
            return GetAllAsync();
        }
        public UserType GetUserTypeById(int id)
        {
            return GetUserTypeById(id);
        }

        public int UpdateUserType(UserType userType)
        {
            return Update(userType);
        }
    }
}
