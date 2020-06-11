using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
   public interface ICampaignDetailsRepository
    {
        int CreateCampaignDetails(CampaignDetails campDetails);
        int DeleteCampaignDetails(CampaignDetails campDetails);
        int UpdateCampaignDetails(CampaignDetails campDetails);
        Task<IEnumerable<CampaignDetails>> GetCampaignDetails();
        CampaignDetails GetCampaignDetails(Int64 campId, int type, Int64 subTypeId);
        CampaignDetails GetCampaignDetailsById(long id);
        CampaignDetails GetCampaignDetailsByCampaignId(long campaignId);
    }
}
