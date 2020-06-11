using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
  public   interface ICampaignDocumentRepository<T> where T:class
    {
        int InsertOrUpdateCampaignDocument(T campDoc);
        int DeleteCampaignDocument(T campDoc);
        int UpdateCampaignDocument(T campDoc);
        IEnumerable<T> GetCampaignDocuments();
        IEnumerable<T> GetCampaignDocuments(long campId);
        IEnumerable<T> GetCampaignMultimedia(long campId);
        T GetCampaignDocumentById(long id);
    }
}
