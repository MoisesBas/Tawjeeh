using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
   public class CenterContactRepository: BaseRepository<CenterContacts>, 
        IContactRepository
    {
        public CenterContactRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public int ContactCreate(CenterContacts contact)
        {
            contact.IsActive = true;
            contact.IsDeleted = false;
            contact.CreatedOn = DateTime.Now;
            return base.Create(contact);
        }
        public int ContactDelete(CenterContacts contact)
        {
            contact.IsDeleted = false;
            contact.UpdatedOn = DateTime.Now;
         return  base.Update(contact);
        }
        public int ContactUpdate(CenterContacts contact)
        {
            contact.UpdatedOn = DateTime.Now;
           return base.Update(contact);
        }    
        public IEnumerable<CenterContacts> GetCenterContactByCenterId(Int64 centerId)
        {            
            var query = @"Select u.* FROM tblCenterContacts u Where u.CenterId = @centerId and u.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<CenterContacts>(query, new { @centerId = centerId });
            }
          
        }
        public Task<IEnumerable<CenterContacts>> GetAllContact()
        {
            return base.GetAllAsync();
        }
        public CenterContacts GetContactById(int id)
        {
            var result = new CenterContacts();
            var query = @"Select u.* FROM tblCenterContacts u Where u.Id = @id and u.IsDeleted=0";
            using (var _conn = _connectionFactory.GetConnection)
            {
                result = _conn.Query<CenterContacts>(query, new { @id = id }).FirstOrDefault();
            }
            return result;
        }
    }
}
