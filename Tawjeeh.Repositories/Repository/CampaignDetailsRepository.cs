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
    public class CampaignDetailsRepository : BaseRepository<CampaignDetails>, 
        ICampaignDetailsRepository
    {
        public CampaignDetailsRepository(IConnectionFactory connectionFactory) :
          base(connectionFactory)
        {

        }

        public int CreateCampaignDetails(CampaignDetails campDetails)
        {
            return base.Create(campDetails);
        }

        public int DeleteCampaignDetails(CampaignDetails campDetails)
        {
            campDetails.IsActive = true;
            campDetails.IsDeleted = true;
            campDetails.UpdatedOn = DateTime.Now;
            return base.Update(campDetails);
        }

        public CampaignDetails GetCampaignDetailsById(long id)
        {
            var query = "Select cd.* FROM tblCampaignDetails cd WHERE cd.Id = @id AND cd.IsActive = 1 AND cd.IsDeleted = 0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<CampaignDetails>(query, new { @id = id }).FirstOrDefault();
            }           
        }
        public CampaignDetails GetCampaignDetailsByCampaignId(long campaignId)
        {
            var query = "Select cd.* FROM tblCampaignDetails cd WHERE cd.CampaignId = @id AND cd.IsActive = 1 AND cd.IsDeleted = 0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<CampaignDetails>(query, new { @id = campaignId }).FirstOrDefault();
            }
        }

        public Task<IEnumerable<CampaignDetails>> GetCampaignDetails()
        {
            return base.GetAllAsync();
        }

        public int UpdateCampaignDetails(CampaignDetails campDetails)
        {
            campDetails.UpdatedOn = DateTime.Now;            
            return base.Update(campDetails);
        }

        public CampaignDetails GetCampaignDetails(long campId, int type, long subTypeId)
        {
            var query = "Select cd.* FROM tblCampaignDetails cd WHERE cd.CampaignId = @campId AND cd.Type = @type AND cd.SubTypeId = @subTypeId AND cd.IsActive = 1 AND cd.IsDeleted = 0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<CampaignDetails>(query, new { @campId = campId, @type=type, @subTypeId= subTypeId }).FirstOrDefault();
            }
        }
    }
}
