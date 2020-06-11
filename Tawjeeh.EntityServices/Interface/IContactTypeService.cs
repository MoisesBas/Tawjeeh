using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityServices.Interface
{
   public interface IContactTypeService
    {
        int InsertOrUpdateContactTypeService(ContactType contype);
        int Delete(ContactType contype);      
        Task<IEnumerable<ContactType>> GetAllContactType();
        ContactType GeTContactTypeByName(string name);
        ContactType GetContactTypeById(long id);
    }
}
