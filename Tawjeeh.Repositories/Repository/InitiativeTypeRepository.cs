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
    public class InitiativeTypeRepository : BaseRepository<InitiativeType>,
        IInitiativeTypeRepository
    {
        public InitiativeTypeRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }
        public int CreateInitiativeType(InitiativeType initiativeType)
        {
            initiativeType.IsActive = true;
            initiativeType.IsDeleted = false;
            initiativeType.CreatedOn = DateTime.Now;
            return base.Create(initiativeType);
        }

        public int DeleteInitiativeType(InitiativeType initiativeType)
        {
            initiativeType.UpdatedOn = DateTime.Now;
            initiativeType.IsDeleted = true;
            return base.Update(initiativeType);
        }

        public Task<IEnumerable<InitiativeType>> GetAll() => GetAllAsync();  

        public InitiativeType GetInitiativeTypeById(int id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblInitiativeType WHERE Id=@id and IsDeleted=0";
                var result = _conn.Query<InitiativeType>(query, new { @id = id });
                return result.FirstOrDefault();
            }
        }

        public int UpdateInitiativeType(InitiativeType initiativeType)
        {           
            initiativeType.UpdatedOn = DateTime.Now;
            return base.Update(initiativeType);
        }
    }
}
