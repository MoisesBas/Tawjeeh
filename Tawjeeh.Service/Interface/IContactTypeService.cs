using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
    public interface IContactTypeService
    {
        int Create(ContactType contype);
        int Delete(ContactType contype);
        int Update(ContactType contype);
        Task<IEnumerable<ContactType>> GetAllContactType();
        ContactType GetContactTypeById(int id);
    }
}
