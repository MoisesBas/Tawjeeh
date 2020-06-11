using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Repositories.Resources;

namespace Tawjeeh.Repositories.Repository
{
    public class EmiratesRepository : BaseRepository<Emirates>,
        IEmiratesRepository
    {
        public EmiratesRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {      }
        public int CreateEmirates(Emirates emirates)
        {
            emirates.IsActive = true;
            emirates.IsDeleted = false;
            emirates.CreatedOn = DateTime.Now;
            return base.Create(emirates);
        }
        public int DeleteEmirates(Emirates emirates)
        {
            emirates.IsDeleted = false;
            emirates.UpdatedOn = DateTime.Now;
            return base.Update(emirates);
        }
        public  async Task<IEnumerable<Emirates>> GetAll()
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = EmiratesQuery.GetAll;
                return await _conn.QueryAsync<Emirates>(query).ConfigureAwait(false);               
            }            
        }
        public Emirates GetEmiratesById(int id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {               
                var query = EmiratesQuery.GetEmiratesById;
                var result = _conn.Query<Emirates>(query, new { @id = id });
                return result.FirstOrDefault();
            }      
        }

        public int UpdateEmirates(Emirates emirates)
        {
            return base.Update(emirates);
        }
    }
}
