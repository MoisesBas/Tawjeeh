using System;
using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
    public interface ICampaignService
    {
        int CreateCampaign(Campaign camp);
        int DeleteCampaign(Campaign camp);
        int UpdateCampaign(Campaign camp);
        IList<Campaign> GetCampaignAll();
        Campaign GetCampaignById(long campaignId);

        int CreateCampaignDetails(CampaignDetails campDetails);
        int DeleteCampaignDetails(CampaignDetails campDetails);
        int UpdateCampaignDetails(CampaignDetails campDetails);
        CampaignDetails GetCampaignDetails(long campId, int type, long subTypeId);
        CampaignDetails GetCampaignDetailsById(long id);
        CampaignDetails GetCampaignDetailsByCampaignId(long campaignId);

        int CreateCampaignDocument(CampaignDocument campDoc);
        int DeleteCampaignDocument(CampaignDocument campDoc);
        int UpdateCampaignDocument(CampaignDocument campDoc);
        IList<CampaignDocument> GetCampaignDocuments();
        IList<CampaignDocument> GetCampaignMultimediaByCampaignId(int campId);
        IList<CampaignMultimedia> GetCampaignMultimedia(long campId);
        CampaignDocument GetCampaignDocumentById(long id);
    }
}
