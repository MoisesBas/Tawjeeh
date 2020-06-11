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
    public class CampaignDocumentRepository : BaseRepository<CampaignDocument>, 
        ICampaignDocumentRepository
    {
        public CampaignDocumentRepository(IConnectionFactory connectionFactory) :
           base(connectionFactory)
        {

        }
        public int CreateCampaignDocument(CampaignDocument campDoc)
        {
            campDoc.IsActive = true;
            campDoc.CreatedOn = DateTime.Now;
            return base.Create(campDoc);
        }

        public int DeleteCampaignDocument(CampaignDocument campDoc)
        {
            campDoc.IsDeleted = true;
            campDoc.UpdatedOn = DateTime.Now;
            return base.Update(campDoc);
        }

        public CampaignDocument GetCampaignDocumentById(long id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblCampaignDocument c WHERE c.Id=@id and c.IsDeleted=0";
                var result = _conn.Query<CampaignDocument>(query, new { @id = id});
                return result.FirstOrDefault();
            }
        }

        public IList<CampaignDocument> GetCampaignDocuments()
        {
            return base.GetAll();
        }

        public IList<CampaignDocument> GetCampaignDocuments(long campId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblCampaignDocument c WHERE c.CampaignId=@id and c.IsDeleted=0";
                var result = _conn.Query<CampaignDocument>(query, new { @id = campId });
                return result.ToList();
            }
        }

        public IList<CampaignMultimedia> GetCampaignMultimedia(long campId)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Query<CampaignMultimedia>("spGetMultimediaCampaign", new { @campaignId = campId },
                    commandType: CommandType.StoredProcedure);
                return result.Count() > 0 ? result.ToList(): new List<CampaignMultimedia>();
            }
        }

        public int UpdateCampaignDocument(CampaignDocument campDoc)
        {
            campDoc.UpdatedOn = DateTime.Now;
            return base.Update(campDoc);
        }
    }
}
