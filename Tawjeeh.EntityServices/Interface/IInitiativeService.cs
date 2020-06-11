using System;
using System.Collections.Generic;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityServices.Interface
{
    public interface IInitiativeService
    {
        IEnumerable<Initiative> GetInitiativeByCampaignId(int campId);
        int InsertOrUpdateInitiative(Initiative initiative);
        int DeleteInitiative(Int64 iniId);
        InitiativeCampaign GetInitiativeCampaignById(int id);
        int InsertOrUpdateInitiativeCampaign(InitiativeCampaign initiativeCamp);
    }
}
