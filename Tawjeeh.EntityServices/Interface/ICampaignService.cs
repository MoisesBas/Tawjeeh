using System.Collections.Generic;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;

namespace Tawjeeh.EntityServices.Interface
{
    public interface ICampaignService
    {
        IEnumerable<CampaignReadOnly> GetCampaignAll();
        CampaignReadOnly GetCampaignById(long campaignId);
        int InsertOrUpdateCampaign(Campaign camp);
        int DeleteCampaign(Campaign camp);
        IEnumerable<CampaignMultimedia> GetCampaignMultimedia(long campId);
        CampaignDetail GetCampaignDetailsByCampaignId(long campaignId);
        int InsertOrUpdateCampaignDoc(CampaignDocument campDoc);
    }
}
