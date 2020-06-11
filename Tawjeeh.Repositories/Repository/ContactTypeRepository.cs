using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class ContactTypeRepository : BaseRepository<ContactType>, 
        IContactTypeRepository
    {
        public ContactTypeRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateContactType(ContactType contype)
        {
            return Create(contype);
        }

        public int DeleteContactType(ContactType contype)
        {
            return Delete(contype);
        }
        public Task<IEnumerable<ContactType>> GetAllContactType()
        {
            return GetAllAsync();
        }
        public ContactType GetContactTypeById(int id)
        {
            return GetContactTypeById(id);
        }
       
        public int UpdateContactType(ContactType contype)
        {
            return Update(contype);
        }
    }
}
