using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Dapper;
using System.Data;
using System.Linq;

namespace Tawjeeh.Repositories.Repository
{
    public class UserRepository : BaseRepository<User>, 
        IUserRepository
    {       
        public UserRepository(IConnectionFactory connectionFactory):
            base(connectionFactory)
        {            
        }
        public bool Login(string userName, string password)
        {            
            var query = @"SELECT u.* FROM tblUser u 
                          WHERE u.UserName = @userName AND u.Password = @password
                          AND u.IsActive = 1 AND u.IsDeleted = 0 AND u.IsOTP=1;";

            using (var _conn = _connectionFactory.GetConnection)
            {
              var  user = _conn.Query<User>(query, new { @userName = userName, @password = password }).FirstOrDefault();
                if (user != null) return true;
                return false;                
            }           
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {           
            var query = @"Select u.*, t.* from tblUser u inner join tblUserType t
                        on u.UserTypeId = t.Id 
                        order by u.Id";

            using (var _conn = _connectionFactory.GetConnection)
            {
                return await _conn.QueryAsync<User, UserType, User>
                (query, (user, type) =>
                {
                    user.Password = string.Empty;
                    user.UserType = type;
                    return user;
                }).ConfigureAwait(false);
            }
        }
       int IUserRepository.Create(User entity)
        {
            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.CreatedOn = DateTime.Now;
            return base.Create(entity);
        }

        int IUserRepository.Update(User entity)
        {           
            entity.UpdatedOn = DateTime.Now;     
            return base.Update(entity);
        }

        int IUserRepository.Delete(User entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedOn = DateTime.Now;
            return base.Update(entity);
        }

        public User GetUserById(int id)
        {
            var user = new User();
           var users = @"Select u.* FROM tblUser u Where Id = @id and u.IsDeleted = 0";

            var query = @"Select a.*, m.* from tblAccessControls a inner join tblMenu m
                        on a.MenuId = m.Id 
                        WHERE a.UserId =@userId
                        order by a.Id ";

            using (var _conn = _connectionFactory.GetConnection)
            {
                user = _conn.Query<User>(users, new { @id = id }).FirstOrDefault();
                if (user != null)
                {

                    var result = _conn.Query<MenuAccess, Menu, MenuAccess>
                    (query, (menuAccess, menu) =>
                    {
                        menuAccess.Menu = menu;
                        return menuAccess;
                    }, new { @userId = id });

                    user.MenuAccess = result.Count() > 0 ? result : null;
                }
            }
            return user;
        }

        public User FindByName(string userName)
        {
            throw new NotImplementedException();
        }       

        public Task<IEnumerable<User>> GetAllUser(int langId)
        {
            throw new NotImplementedException();
        }

        public User IsUserExist(string userName)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblUser WHERE UserName=@userName and IsDeleted = 0;";
                var result = _conn.Query<User>(query,
                  new { @userName = userName });

                return result.FirstOrDefault();
            }
        }

        public User IsUserExist(string userName, string mobileNo)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblUser WHERE UserName=@userName AND MobileNo=@mobileNo AND IsDeleted = 0";
                var result = _conn.Query<User>(query,
                  new { @userName = userName,@mobileNo=mobileNo });

                return result.FirstOrDefault();
            }
        }

        public async  Task<User> GetUserbyCredential(string userName, string password)
        {           
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblUser WHERE UserName=@userName AND Password=@password and IsDeleted = 0";
                var query2 = @"Select a.*, m.* from tblAccessControls a inner join tblMenu m
                        on a.MenuId = m.Id 
                        WHERE a.UserId =@userId
                        order by a.Id ";

                var result = await _conn.QueryAsync<User>(query, new { @userName = userName, @password = password }).ConfigureAwait(false);               
                var users = result.FirstOrDefault();

                if (users != null)
                {
                    var query3 = _conn.Query<MenuAccess, Menu, MenuAccess>
                    (query2, (menuAccess, menu) =>
                    {
                        menuAccess.Menu = menu;
                        return menuAccess;
                    }, new { @userId = users.Id });

                   users.MenuAccess = query3.Count() > 0 ? query3 : null;
                }

                return users;
            }

        }

        public IEnumerable<User> GetAllUserByUserType(long userTypeId)
        {
            var query = @"Select u.* From tblUser u where u.UserTypeId = @userTypeId and u.IsDeleted = 0;                          
                          Select cc.* From tblCenterContacts cc inner join tblUser u
                          on cc.UserId = u.Id WHERE u.UserTypeId = @userTypeId and cc.IsDeleted = 0;
                          Select c.* FROM tblCenters c inner join 
                          tblCenterContacts cc on c.Id = cc.CenterId inner join
                          tblUser u on cc.UserId = u.Id 
                          WHERE u.UserTypeId = @userTypeId and c.IsDeleted = 0;";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.QueryMultiple(query, new { @userTypeId = userTypeId });
                var user = result.Read<User>().ToList();
                var usercontacts = result.Read<CenterContacts>().ToList();
                var centers = result.Read<Centers>().ToList();               
                var output = (from u in user
                              select new User
                              {
                                  Id = u.Id,
                                  UserTypeId = u.UserTypeId,
                                  ContactTypeId = (from ct in usercontacts
                                                  where ct.UserId == u.Id
                                                  select ct.ContactTypeId).FirstOrDefault(),
                                  JobTitle = u.JobTitle,
                                  UserName = u.UserName,
                                  Password = string.Empty,
                                  FullName = u.FullName,
                                  OfficeNo = u.OfficeNo,
                                  Department = u.Department,
                                  MobileNo = u.MobileNo,
                                  Email = u.Email,
                                  IsActive = u.IsActive,
                                  IsDeleted = u.IsDeleted,
                                  CreatedOn = u.CreatedOn,
                                  CreatedBy = u.CreatedBy,
                                  UpdatedBy = u.UpdatedBy,
                                  UpdatedOn = u.UpdatedOn,
                                  CenterId = (from  cc in usercontacts   where cc.UserId == u.Id 
                                              select cc.CenterId).FirstOrDefault(),
                                  Contacts = (from cc in usercontacts
                                                         where cc.UserId == u.Id
                                                         select cc).FirstOrDefault(),
                                  Center = (from c in centers
                                            join cc in usercontacts on c.Id equals cc.CenterId
                                            where cc.UserId == u.Id
                                            select new Centers {
                                                Id = c.Id,
                                                Name = c.Name,
                                                LocationAddress = c.LocationAddress,
                                                EmiratesId = c.EmiratesId,
                                                TradeLicense = c.TradeLicense,
                                                Longitude = c.Longitude,
                                                Latitude = c.Latitude,
                                                IsActive = c.IsActive,
                                                IsDeleted = c.IsDeleted,
                                                CreatedBy = c.CreatedBy,
                                                CreatedOn = c.CreatedOn,
                                                UpdatedBy = c.UpdatedBy,
                                                UpdatedOn = c.UpdatedOn,
                                                TradeLicenseExpiryDate = c.TradeLicenseExpiryDate,
                                                FaxNo = c.FaxNo,
                                                PhoneNo = c.PhoneNo,
                                                WebSite = c.WebSite,
                                                Email = c.Email,
                                                Contacts = (from con in usercontacts
                                                            where con.CenterId == c.Id
                                                            select con).ToList()
                                                
                                            }).FirstOrDefault()

                              }).ToList();

                return output;
            }
        }

        public int RegisterUser(User user)
        {
            return base.Create(user);
        }
    }
}
