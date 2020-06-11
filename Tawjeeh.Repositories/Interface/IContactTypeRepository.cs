using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IContactTypeRepository
    {
        int Create(ContactType contype);
        int Delete(ContactType contype);
        int Update(ContactType contype);
        Task<IEnumerable<ContactType>> GetAllContactType();
        ContactType GetContactTypeById(int id);

        
    }
}
