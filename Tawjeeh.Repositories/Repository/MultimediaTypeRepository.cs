using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class MultimediaTypeRepository: BaseRepository<MultimediaType>, 
        IMultimediaTypeRepository
    {
        public MultimediaTypeRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public IList<MultimediaType> GetAllMultimediaType()
        {
            var query = @"select * from tblMultimediaType where IsDelete = 0";          
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<MultimediaType>(query).ToList();
            }
           

        }
    }
}
