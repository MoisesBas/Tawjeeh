using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface ICampaignDetailsRepository<T> where T:class
    {
        int InsertOrUpdateCampaignDetails(T campDetails);
        int DeleteCampaignDetails(T campDetails);      
        Task<IEnumerable<T>> GetCampaignDetails();
        T GetCampaignDetails(Int64 campId, int type, Int64 subTypeId);
        T GetCampaignDetailsById(long id);
        T GetCampaignDetailsByCampaignId(long campaignId);
    }
}
