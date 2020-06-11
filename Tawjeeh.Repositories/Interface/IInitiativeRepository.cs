using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IInitiativeRepository
    {
        int CreateInitiative(Initiative initiative);
        int DeleteInitiative(Int64 iniId);
        int UpdateInitiative(Initiative initiative);
        IList<Initiative> GetAll();
        IList<Initiative> GetInitiativeByCampaignId(long campaignId);
        Initiative GetInitiativeById(long id);
    }
}
