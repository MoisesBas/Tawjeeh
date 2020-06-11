using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class DecisionMultimediaRepository : BaseRepository<DecisionMultimedia>, 
        IDecisionMultimediaRepository
    {
        public DecisionMultimediaRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            decisionmultimedia.IsActive = true;
            decisionmultimedia.IsDeleted = false;
            decisionmultimedia.CreatedOn = DateTime.Now;
            return base.Create(decisionmultimedia);
        }
        public int DeleteDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            decisionmultimedia.UpdatedOn = DateTime.Now;
            decisionmultimedia.IsDeleted = true;
            return base.Update(decisionmultimedia);
        }
        public IList<DecisionMultimedia> GetDecisionMultimediaAll()
        {
            var query = @"Select am.* FROM tblDecisionMultimedia am where am.IsDeleted=0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<DecisionMultimedia>(query).ToList();
            }
            
        }
        public IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaId(long decisionId)
        {
            var query = @"Select am.* FROM tblDecisionMultimedia am 
                          WHERE am.DecisionId = @decisionId and am.IsDeleted=0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<DecisionMultimedia>(query, new { @decisionId = decisionId }).ToList();
            }
        }

        public IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaIdAndLangId(long decisionId, int langId)
        {
            var query = @"Select am.* FROM tblDecisionMultimedia am 
                          WHERE am.Id = @decisionId and am.LangId=@langId and am.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<DecisionMultimedia>(query, new { @decisionId = decisionId, @langId = langId }).ToList();
            }
        }

        public DecisionMultimedia GetDecisionMultimediaById(long decisionmultimediaId)
        {
            var query = @"Select am.* FROM tblDecisionMultimedia am 
                          WHERE am.Id = @decisionmultimediaId and am.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<DecisionMultimedia>(query, new { @decisionmultimediaId = decisionmultimediaId }).FirstOrDefault();
            }
        }

        public DecisionMultimedia GetDecisionMultimediaByName(string name, long decisionmultimediaId)
        {
            var query = @"Select * FROM tblDecisionMultimedia am 
                          WHERE am.Id = @decisionmultimediaId and am.IsDeleted=0
                          and am.FileName = @name";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<DecisionMultimedia>(query, new { @decisionmultimediaId = @decisionmultimediaId,@name =name }).FirstOrDefault();
            }
        }       

        public int UpdateDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            decisionmultimedia.UpdatedOn = DateTime.Now;
            return base.Update(decisionmultimedia);
        }

        public bool SetDecisionMultimediaStatus(long mediaDecisionId)
        {
            var isexist = this.GetDecisionMultimediaById(mediaDecisionId);
            isexist.IsMobile = isexist.IsMobile == true ? false : true;
            var result = base.Update(isexist);
            if (result > 0) return true;
            return false;
        }
    }
}
