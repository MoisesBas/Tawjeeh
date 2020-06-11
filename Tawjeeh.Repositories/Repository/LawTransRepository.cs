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

    public class LawTransRepository : BaseRepository<LawTrans>,
        ILawTransRepository
    {
        public LawTransRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public int CreateLawTrans(LawTrans lawtrans)
        {
            lawtrans.CreatedOn = DateTime.Now;
            lawtrans.IsActive = true;
            lawtrans.IsDeleted = false;
            return base.Create(lawtrans);
        }

        public int DeleteLawTrans(LawTrans lawtrans)
        {
            lawtrans.IsDeleted = true;
            lawtrans.UpdatedOn = DateTime.Now;
            return base.Update(lawtrans);
        }

        public async Task<IEnumerable<LawTrans>> GetLawTransAll()
        {
            var query = @"Select * FROM tblLawTrans where IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return await _conn.QueryAsync<LawTrans>(query).ConfigureAwait(false);
            }           
        }

        public LawTrans GetLawTransId(int id)
        {
            var query = @"Select * FROM tblLawTrans lt where lt.Id =@id and lt.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return  _conn.Query<LawTrans>(query, new { @id=id}).FirstOrDefault();
            }
            
        }

        public LawTrans GetLawTransId(long lawId, int langId)
        {
            var query = @"Select * FROM tblLawTrans lt where lt.Id =@id and lt.LangId = @langId and lt.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<LawTrans>(query, new { @id = lawId, @langId = langId }).FirstOrDefault();
            }
        }

        public int UpdateLawTrans(LawTrans lawtrans)
        {
            lawtrans.UpdatedOn = DateTime.Now;
            return base.Update(lawtrans);
        }

        public LawTrans GetLawTrans(Int64 lawId, int langId )
        {
            var query = @"Select * FROM tblLawTrans lt where lt.LawId =@lawId and lt.LangId=@langId and lt.IsDeleted=0 ";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<LawTrans>(query, new { @lawId = lawId, @langId = langId }).FirstOrDefault();
            }

        }

        public IList<LawTrans> GetLawTransByLawId(long lawId)
        {
            var query = @"Select lt.* FROM tblLawTrans lt where lt.LawId =@lawId and lt.IsDeleted=0 ";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<LawTrans>(query, new { @lawId = lawId}).ToList();
            }
        }
    }

}
