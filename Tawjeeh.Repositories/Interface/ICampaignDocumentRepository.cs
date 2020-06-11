using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface ICampaignDocumentRepository
    {
        int CreateCampaignDocument(CampaignDocument campDoc);
        int DeleteCampaignDocument(CampaignDocument campDoc);
        int UpdateCampaignDocument(CampaignDocument campDoc);
        IList<CampaignDocument> GetCampaignDocuments();
        IList<CampaignDocument> GetCampaignDocuments(long campId);
        IList<CampaignMultimedia> GetCampaignMultimedia(long campId);
        CampaignDocument GetCampaignDocumentById(long id);
    }
}
