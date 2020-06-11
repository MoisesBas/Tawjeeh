using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IUserTypeRepository{Tawjeeh.EntityModel.UserType}" />
    public class UserTypeRepository : RepositoryBase<TawjeehContext>,
         IUserTypeRepository<UserType>
    {
        /// <summary>
        /// Creates the type of the user.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int CreateUserType(UserType userType)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Deletes the type of the user.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int DeleteUserType(UserType userType)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IEnumerable<UserType>> GetAll()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Gets the user type by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public UserType GetUserTypeById(int id)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Updates the type of the user.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int UpdateUserType(UserType userType)
        {
            throw new System.NotImplementedException();
        }
    }
}
