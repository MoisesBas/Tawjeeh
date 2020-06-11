using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Dapper;
using System.Linq;

namespace Tawjeeh.Repositories.Repository
{
    public class MenuRepository : BaseRepository<Menu>, 
        IMenuRepository
    {
        public MenuRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
        public int CreateMenu(Menu menu)
        {
            return Create(menu);
        }
        public int DeleteMenu(Menu menu)
        {
            return Delete(menu);
        }
        public Task<IEnumerable<Menu>> GetAll()
        {
            return GetAllAsync();
        }
        public Menu GetMenusById(int id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblMenu WHERE Id=@id";
                var result = _conn.Query<Menu>(query, new { @id = id});               
                return result.FirstOrDefault();
            }
        }
        public int UpdateMenu(Menu menu)
        {
            return Update(menu);
        }
    }
}
