using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
   public interface IContactRepository
    {
        int ContactCreate(CenterContacts contact);
        int ContactDelete(CenterContacts contact);
        int ContactUpdate(CenterContacts contact);        
        Task<IEnumerable<CenterContacts>> GetAllContact();
        CenterContacts GetContactById(int id);
        IEnumerable<CenterContacts> GetCenterContactByCenterId(Int64 centerId);
    }
}
