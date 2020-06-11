using System;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.SMSBulkSending.InitiativeCampaign
{
    public class InitiativeCampaignProcess : IInitiativeJobService
    {
        public IInitiativeCampaignStatus _initiativeCampaignStatus;
        public InitiativeCampaignProcess(IInitiativeCampaignStatus initiativeCampaignStatus)
        {
            Guard.NotNull(initiativeCampaignStatus, nameof(initiativeCampaignStatus));
            _initiativeCampaignStatus = initiativeCampaignStatus;
        }
        public void Execute()
        {
           var campaign =  _initiativeCampaignStatus.AddItemInInitiativeCampaigns();
            _initiativeCampaignStatus.ProcessCampaign(campaign);
        }

    }
}
