using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel.ReadOnly;

namespace Tawjeeh.EntityFramework.Interface
{
  public  interface ICampaignRepository<T> where T:class
    {
        int InsertOrUpdateCampaing(T camp);       
        int DeleteCampaign(T camp);   
        IEnumerable<T> GetCampaigns();
        IEnumerable<T> GetCampaignById(long id);
        IEnumerable<CampaignMultimedia> GetCampaignMultimedias(long id);
    }
}
