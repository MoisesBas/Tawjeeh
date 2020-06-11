using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;


namespace Tawjeeh.Repositories.Repository
{
    public class MenuAccessRepository : BaseRepository<MenuAccess>, 
        IUserAccessRepository
    {
        public MenuAccessRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public int CreateUserAccess(MenuAccess access)
        {
            return base.Create(access);
        }
        public int CreateBatchUserAccess(List<MenuAccess> access)
        {
            var output = 0;
            using (var _conn = _connectionFactory.GetConnection)
            {
                using (var trans = _conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var a in access)
                        {
                            var result = GetMenuAccessById(a.UserId,a.MenuId);                         
                            output = result != null ? base.Update(a) 
                                :  base.Create(a);
                        }
                        output = 1;
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        output = 0;
                        trans.Rollback();
                    }

                }

            }
            return output;
        }
        public int DeleteUserAccess(MenuAccess access)
        {
            return base.Delete(access);
        }

        public Task<IEnumerable<MenuAccess>> GetAll()
        {
            return base.GetAllAsync();
        }
        
        public MenuAccess GetMenuAccessById(long userId, long menuId)
        {
            var result = new MenuAccess();
            var query = @"Select u.* FROM tblAccessControls u Where u.UserId = @userId and u.MenuId =@menuId";
            using (var _conn = _connectionFactory.GetConnection)
            {
                result = _conn.Query<MenuAccess>(query, new { @userId = userId, 
                                                 @menuId = menuId }).FirstOrDefault();
            }
            return result;
        }
        public MenuAccess GetMenuAccessById(int id)
        {
            var result = new MenuAccess();
            var query = @"Select a.*, u.* FROM tblAccessControls a inner join tblUser u
                        on u.Id = a.Id ORDER BY a.Id
                         WHERE a.Id = @id";

            using (var _conn = _connectionFactory.GetConnection)
            {
                result = _conn.Query<MenuAccess, User, MenuAccess>
                (query, (menu, user) =>
                {
                    menu.User = user;
                    return menu;
                }, new { @id = id }).FirstOrDefault();
            }
            return result;
        }

        public Task<IEnumerable<MenuAccess>> GetMenuAccessByMenuId(int menuId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuAccess>> GetMenuAccessByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public int UpdateUserAccess(MenuAccess access)
        {
            throw new NotImplementedException();
        }


    }
}
