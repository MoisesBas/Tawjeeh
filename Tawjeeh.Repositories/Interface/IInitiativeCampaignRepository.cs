using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
   public interface IInitiativeCampaignRepository
    {
        int CreateInitiativeCampaign(InitiativeCampaign initiativeCampaign);
        int DeleteInitiativeCampaign(InitiativeCampaign initiativeCampaign);
        int UpdateInitiativeCampaign(InitiativeCampaign initiativeCampaign);
        Task<IEnumerable<InitiativeCampaign>> GetAll();
        InitiativeCampaign GetInitiativeCampaignById(int id);
        IList<InitiativeCampaign> GetInitiativeCampaignByCampaignId(int campId);
    }
}
