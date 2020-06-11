using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
   public interface IInitiativeService
    {
        int CreateInitiativeCampaign(InitiativeCampaign initiativeCampaign);
        int DeleteInitiativeCampaign(InitiativeCampaign initiativeCampaign);
        int UpdateInitiativeCampaign(InitiativeCampaign initiativeCampaign);
        Task<IEnumerable<InitiativeCampaign>> GetInitiativeCampaignAll();
        InitiativeCampaign GetInitiativeCampaignById(int id);

        int CreateInitiative(Initiative initiative);
        int DeleteInitiative(Int64 iniId);
        int UpdateInitiative(Initiative initiative);
        IList<Initiative> GetInitiativeAll();
        Initiative GetInitiativeById(long id);
        IList<InitiativeCampaign> GetInitiativeCampaignByCampaignId(int campId);
        IList<Initiative> GetInitiativeByCampaignId(int campId);

        int CreateInitiativeType(InitiativeType initiativeType);
        int DeleteInitiativeType(InitiativeType initiativeType);
        int UpdateInitiativeType(InitiativeType initiativeType);
        Task<IEnumerable<InitiativeType>> GetInitiativeTypeAll();
        InitiativeType GetInitiativeTypeById(int id);
    }
}
