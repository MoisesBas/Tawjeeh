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
   public class CenterTransRepository : BaseRepository<CenterTrans>,
        ICenterTransRepository
    {
        public CenterTransRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        { }
        public int CreateCenterTrans(CenterTrans centerTrans)
        {
            return base.Create(centerTrans);
        }
        public int DeleteCenterTrans(CenterTrans center)
        {
            return base.Delete(center);
        }
        public Task<IEnumerable<CenterTrans>> GetCenterTransAll()
        {
            return base.GetAllAsync();
        }
        public IList<CenterTrans> GetCenterTransByCenterId(long centerId)
        {
            var query = @"Select u.* FROM tblCenterTrans u Where u.Id = @centerId and u.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<CenterTrans>(query, new { @centerId = centerId }).ToList();
            }
        }
        public CenterTrans GetCenterTransId(int id)
        {
            var result = new CenterTrans();
            var query = @"Select u.* FROM tblCenterTrans u Where u.Id = @id and u.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                result = _conn.Query<CenterTrans>(query, new { @id = id }).FirstOrDefault();
            }
            return result;
        }      
        public CenterTrans GetCenterTransId(long centerId, int langId)
        {
            var result = new CenterTrans();
            var query = @"Select u.* FROM tblCenterTrans u
                          where u.CenterId = @centerId AND u.LangId = @langId and u.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                result = _conn.Query<CenterTrans>(query, new { @centerId = centerId, @langId = langId }).FirstOrDefault();
            }
            return result;
        }
        public int UpdateCenterTrans(CenterTrans center)
        {
            return base.Update(center);
        }
    }
}
