using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IInitiativeTypeRepository
    {
        int CreateInitiativeType(InitiativeType initiativeType);
        int DeleteInitiativeType(InitiativeType initiativeType);
        int UpdateInitiativeType(InitiativeType initiativeType);
        Task<IEnumerable<InitiativeType>> GetAll();
         InitiativeType GetInitiativeTypeById(int id);
    }
}
