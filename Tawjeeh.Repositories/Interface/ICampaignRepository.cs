using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface ICampaignRepository
    {
        int CreateCampaign(Campaign camp);
        int DeleteCampaign(Campaign camp);
        int UpdateCampaign(Campaign camp);
        IList<Campaign> GetCampaigns();
        Campaign GetCampaignById(long id); 
    }
}
