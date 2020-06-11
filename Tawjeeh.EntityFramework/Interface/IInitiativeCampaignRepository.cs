using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
  public  interface IInitiativeCampaignRepository<T> where T:class
    {
        int InsertOrUpdateInitiativeCampaign(T initiativeCampaign);
        int DeleteInitiativeCampaign(T initiativeCampaign);       
        Task<IEnumerable<T>> GetAll();
        T GetInitiativeCampaignById(int id);
        IEnumerable<T> GetInitiativeCampaignByCampaignId(int campId);
    }
}
