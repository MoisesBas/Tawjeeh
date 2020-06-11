using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class UtilityRepository : BaseRepository<MobileSearch>, IUtilityRepository
    {
        public UtilityRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
        public IList<MobileSearch> GetAllMobileSearch()
        {
            return base.GetAll();
        }

        public IList<MobileSearch> GetAllMobileSearch(int langId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM [dbo].[vwSearchMobile] c WHERE c.LangId=@id;";
                var result = _conn.Query<MobileSearch>(query, new { @id = langId });
                return result.ToList();
            }
        }

        public Dashboard GetDashboard(int year, int type)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {               
                var result = _conn.Query<Dashboard>("Dashbord", new { @year = year, @type = type }, commandType: System.Data.CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
    }
}
