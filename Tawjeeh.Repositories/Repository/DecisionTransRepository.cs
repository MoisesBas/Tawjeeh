using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class DecisionTransRepository : BaseRepository<DecisionTrans>, 
        IDecisionTransRepository
    {
        public DecisionTransRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateDecisionTrans(DecisionTrans decisionTrans)
        {
            decisionTrans.IsActive = true;
            decisionTrans.IsDeleted = false;
            decisionTrans.CreatedOn = DateTime.Now;
            return base.Create(decisionTrans);
        }

        public int DeleteDecisionTrans(DecisionTrans decisionTrans)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Execute("DeleteDecisionTrans", new { @TransDecisionId = decisionTrans.Id, @LangId = decisionTrans.LangId, @UpdatedBy = decisionTrans.UpdatedBy },
                    commandType: CommandType.StoredProcedure);
                if (result == -1) result = 1;
                return result;
            }
        }

        public IList<DecisionTrans> GetDecisionsAllTrans()
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT dt.* FROM tblDecisionTrans dt where dt.IsDeleted=0;";
                return  _conn.Query<DecisionTrans>(query).ToList();               
            }
           
        }

        public int UpdateDecisionTrans(DecisionTrans decisionTrans)
        {
            decisionTrans.UpdatedOn = DateTime.Now;
            return base.Update(decisionTrans);
        }

        public DecisionTrans GetDecisionTransByName(string name, int langId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblDecisionTrans WHERE Name=@name and LangId = @langId and IsDeleted=0";
                var result = _conn.Query<DecisionTrans>(query, new { @name = name, @langId = langId });
                return result.FirstOrDefault();
            }
        }

        public DecisionTrans GetdecisionTransById(int id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT dt.* FROM tblDecisionTrans dt WHERE dt.Id=@id and dt.IsDeleted=0";
                var result = _conn.Query<DecisionTrans>(query, new { @id=id });
                return result.FirstOrDefault();
            }
        }

        public DecisionTrans GetdecisionTransLangIdAndId(long decisionId, int langId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT dt.* FROM tblDecisionTrans dt WHERE dt.Id=@id and dt.LangId=@langId and dt.IsDeleted=0";
                var result = _conn.Query<DecisionTrans>(query, new { @id = decisionId, @langId = langId });
                return result.FirstOrDefault();
            }
        }        

        public DecisionTrans GetdecisionTransByLangIdArticleIdAndLangId(Int64 articleId, int langId, Int64 decisionId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT dt.* FROM tblDecisionTrans dt WHERE dt.Id=@id and dt.LangId=@langId and dt.ArticleId=@articleId and dt.IsDeleted=0";
                var result = _conn.Query<DecisionTrans>(query, new { @id = decisionId, @langId = langId, });
                return result.FirstOrDefault();
            }
        }

        public DecisionTrans GetdecisionTransByDecisionIdAndLangId(long decisionId, int langId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT dt.* FROM tblDecisionTrans dt WHERE dt.DecisionId=@id and dt.LangId=@langId and dt.IsDeleted=0";
                var result = _conn.Query<DecisionTrans>(query, new { @id = decisionId, @langId = langId });
                return result.FirstOrDefault();
            }
        }

       public DecisionTrans GetdecisionTransLangIdAndDecisionId(long decisionId, int langId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = @"SELECT Top 1 dt.* FROM tblDecisionTrans dt WHERE dt.DecisionId=@id AND dt.LangId=@langId AND dt.IsDeleted=0;
                              SELECT dm.* FROM tblDecisionMultimedia dm WHERE dm.DecisionId=@id AND dm.LangId=@langId AND dm.IsDeleted=0;";

                var _result = this.GetMultiple(query, false, new { @id = decisionId, @langId = langId },
                                              r => r.Read<DecisionTrans>(),
                                              r => r.Read<DecisionMultimedia>());
                var decisions = _result.Item1.ToList();
                var decisionMultimedia = _result.Item2.ToList();
                var result = (from r in decisions
                              select new DecisionTrans {
                                  ArticleId = r.ArticleId,
                                  Name = r.Name,
                                  Description = r.Description,
                                  DecisionId = r.DecisionId,
                                  DecisionNo = r.DecisionNo,
                                  LangId = r.LangId,
                                  IsActive = r.IsActive,
                                  IsDeleted = r.IsDeleted,
                                  CreatedBy = r.CreatedBy,
                                  CreatedOn = r.CreatedOn,
                                  UpdatedBy = r.UpdatedBy,
                                  UpdatedOn = r.UpdatedOn,
                                  Id = r.Id,
                                  DecisionMultimedia = (from d in decisionMultimedia
                                                        select d).ToList()                                  
                              }).ToList();

                return result.FirstOrDefault();
            }
        }
    }
}
