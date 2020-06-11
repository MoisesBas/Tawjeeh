using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class ContactTypeService : IContactTypeService
    {
        private IContactTypeRepository _contypeRepo;
        public ContactTypeService(IContactTypeRepository contypeRepo)
        {
            Guard.NotNull(contypeRepo, nameof(contypeRepo));
            _contypeRepo = contypeRepo;
        }

        public int Create(ContactType contype)
        {
            return _contypeRepo.Create(contype);
        }

        public int Delete(ContactType contype)
        {
            return _contypeRepo.Delete(contype);
        }

        public Task<IEnumerable<ContactType>> GetAllContactType()
        {
            return _contypeRepo.GetAllContactType();
        }

        public ContactType GetContactTypeById(int id)
        {
            return _contypeRepo.GetContactTypeById(id);
        }
        public int Update(ContactType contype)
        {
            return _contypeRepo.Update(contype);
        }
    }
}
