using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class CenterRepository : BaseRepository<Centers>, 
        ICenterRepository
    {
        public CenterRepository(IConnectionFactory connectionFactory) 
            : base(connectionFactory)
        {

        }
        public int CreateCenter(Centers center)
        {
            center.CreatedOn = DateTime.Now;
            center.IsActive = true;
            center.IsDeleted = false;
            return base.Create(center);
        }
        public int DeleteCenter(Centers center)
        {            
            center = this.GetCenterById(Convert.ToInt32(center.Id));           
            center.IsDeleted = true;
            center.UpdatedOn = DateTime.Now;
            return base.Update(center);
        }
        public IEnumerable<Centers> GetAll(int langId)
        { 
            var _result = this.GetMultiple("spGetCentersAllByLangId", true,new { @langId = langId},
                                                r => r.Read<Centers>(),
                                                r => r.Read<Emirates>(),
                                                r => r.Read<CenterTrans>());            
       
                var centers = _result.Item1.ToList();
                var emirates = _result.Item2.ToList();
                var centersTrans = _result.Item3.ToList();
                var output = (from c in centers
                              join e in emirates on c.EmiratesId equals e.Id
                              select new Centers
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  LocationAddress = c.LocationAddress,
                                  EmiratesId = c.EmiratesId,
                                  TradeLicense = c.TradeLicense,
                                  Longitude = c.Longitude,
                                  Latitude = c.Latitude,
                                  IsActive = c.IsActive,
                                  IsDeleted = c.IsDeleted,
                                  CreatedOn = c.CreatedOn,
                                  CreatedBy = c.CreatedBy,
                                  UpdatedOn = c.UpdatedOn,
                                  UpdatedBy = c.UpdatedBy,
                                  TradeLicenseExpiryDate = c.TradeLicenseExpiryDate,
                                  FaxNo = c.FaxNo,
                                  PhoneNo = c.PhoneNo,
                                  WebSite = c.WebSite,
                                  Email = c.Email,
                                  Emirates = e,
                                  CenterTranslation = (from ct in centersTrans
                                                       where ct.CenterId == c.Id
                                                       select ct).ToList(),
                              }).ToList();
                return output;

        }
        public override IList<Centers> GetAll()
        {
           
            var _result = this.GetMultiple("spGetAllCenters",true, null,
                                                r => r.Read<Centers>(),
                                                r => r.Read<Emirates>(),
                                                r => r.Read<CenterTrans>(),
                                                r => r.Read<CenterContacts>(),
                                                r => r.Read<User>());
            
                var centers = _result.Item1.ToList();
                var emirates = _result.Item2.ToList();
                var centersTrans = _result.Item3.ToList();
                var centersContacts = _result.Item4.ToList();
                var users = _result.Item5.ToList();

                var output = (from c in centers
                              join e in emirates on c.EmiratesId equals e.Id
                              select new Centers
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  LocationAddress = c.LocationAddress,
                                  EmiratesId = c.EmiratesId,
                                  TradeLicense = c.TradeLicense,
                                  TradeLicenseExpiryDate = c.TradeLicenseExpiryDate,
                                  FaxNo = c.FaxNo,
                                  PhoneNo = c.PhoneNo,
                                  WebSite = c.WebSite,
                                  Email = c.Email,
                                  Longitude = c.Longitude,
                                  Latitude = c.Latitude,
                                  IsActive = c.IsActive,
                                  IsDeleted = c.IsDeleted,
                                  CreatedOn = c.CreatedOn,
                                  CreatedBy = c.CreatedBy,
                                  UpdatedOn = c.UpdatedOn,
                                  UpdatedBy = c.UpdatedBy,
                                  Emirates = e,
                                  CenterTranslation = (from ct in centersTrans
                                                       where ct.CenterId == c.Id
                                                       select ct).ToList(),
                                  Contacts = (from cc in centersContacts
                                              where cc.CenterId == c.Id
                                              select new CenterContacts
                                              {
                                                  Id = cc.Id,
                                                  CenterId = cc.CenterId,
                                                  UserId = cc.UserId,
                                                  ContactTypeId = cc.ContactTypeId,
                                                  IsActive = cc.IsActive,
                                                  IsDeleted = cc.IsDeleted,
                                                  CreatedOn = cc.CreatedOn,
                                                  CreatedBy = cc.CreatedBy,
                                                  UpdatedBy = cc.UpdatedBy,
                                                  UpdatedOn = cc.UpdatedOn,
                                                  Users = (from u in users
                                                           where u.Id == cc.UserId
                                                           select new User {
                                                               Id = u.Id,
                                                               UserTypeId = u.UserTypeId,
                                                               UserName = u.UserName,
                                                               Password = string.Empty,
                                                               FullName = u.FullName,
                                                               OfficeNo = u.OfficeNo,
                                                               Department = u.Department,
                                                               JobTitle = u.JobTitle,
                                                               MobileNo = u.MobileNo,
                                                               Email = u.Email,
                                                               IsOTP = u.IsOTP,
                                                               OTP = string.Empty,
                                                               LangId = u.LangId,
                                                               CountryId = u.CountryId,
                                                               IsActive = u.IsActive,
                                                               IsDeleted = u.IsDeleted,
                                                               CreatedBy = u.CreatedBy,
                                                               CreatedOn = u.CreatedOn,
                                                               UpdatedBy = u.UpdatedBy,
                                                               UpdatedOn = u.UpdatedOn
                                                           }).FirstOrDefault()
                                              }).ToList()
                              }).ToList();
                return output;
           
            
        }
        public Centers GetCenterById(int id)
        {
            var qrycenters = @"SELECT u.*, e.* FROM dbo.tblCenters u 
                                inner join tblEmirates e on u.EmiratesId = e.Id
                                WHERE u.Id =@id and u.IsDeleted=0 and e.IsDeleted=0;";

            var qrycontacts = @"SELECT cc.*,u.* FROM tblCenterContacts cc 
                                inner join tblUser u on u.Id = cc.UserId
                                WHERE cc.CenterId = @id and cc.IsDeleted=0 and u.IsDeleted=0";


            using (var _conn = _connectionFactory.GetConnection)
            {
                var resultCenters = _conn.Query<Centers, Emirates, Centers>
               (qrycenters, (center, emirate) =>
               {
                   center.Emirates = emirate;
                   return center;
               }, new { @id = id }).FirstOrDefault();

                var resultContact = _conn.Query<CenterContacts, User, CenterContacts>
               (qrycontacts, (contact, user) =>
               {
                   user.Password = string.Empty;
                   user.ContactTypeId = contact.ContactTypeId;
                   contact.Users = user;
                   return contact;
               }, new { @id = id });

                if (resultCenters != null)
                {
                    if (resultContact.Count() > 0)
                        resultCenters.Contacts = resultContact.ToList();
                }

                return resultCenters;
            }

        }
        public Centers GetCenterById(int id, int langId)
        {
            var qrycenters = @"SELECT u.*, e.*, ct.* FROM dbo.tblCenters u 
                                inner join tblEmirates e on u.EmiratesId = e.Id
                                inner join tblCenterTrans ct on u.Id = ct.CenterId
                                WHERE ct.LangId=@langId And u.Id =@id and e.IsDeleted=0;";

            var qrycontacts = @"SELECT cc.*,u.* FROM tblCenterContacts cc 
                                inner join tblUser u on u.Id = cc.UserId
                                WHERE cc.CenterId = @id and u.IsDeleted=0;";

            using (var _conn = _connectionFactory.GetConnection)
            {
                var resultCenters = _conn.Query<Centers, Emirates, CenterTrans, Centers>
               (qrycenters, (center, emirate, trans) =>
               {
                   center.Emirates = emirate;
                   center.CenterTranslation.Add(trans);
                   return center;
               }, new { @id = id, @langId = langId }).FirstOrDefault();

                var resultContact = _conn.Query<CenterContacts, User, CenterContacts>
               (qrycontacts, (contact, user) =>
               {
                   user.Password = string.Empty;
                   user.ContactTypeId = contact.ContactTypeId;
                   contact.Users = user;
                   return contact;
               }, new { @id = id });

                if (resultCenters != null)
                {
                    if (resultContact.Count() > 0)
                        resultCenters.Contacts = resultContact.ToList();
                }

                return resultCenters;
            }

        }
        public async Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId)
        {
            var query = @"Select c.*, e.* from tblCenters c inner join tblEmirates e
                        on e.Id = c.EmiratesId 
                          WHERE e.Id = @Id and c.IsDeleted=0 and e.IsDeleted=0
                        ORDER BY c.Name";

            using (var _conn = _connectionFactory.GetConnection)
            {
                return await _conn.QueryAsync<Centers, Emirates, Centers>
                (query, (centers, emirates) =>
                {
                    centers.Emirates = emirates;
                    return centers;
                }, new { @id = emiratesId }).ConfigureAwait(false);
            }
        }
        public async Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId, int langId)
        {
            var query = @"Select c.* from tblCenters c WHERE c.EmiratesId =@emiratesId and c.IsDeleted=0;
                          Select e.* from tblEmirates e WHERE e.Id = @emiratesId and e.IsDeleted=0;
                          Select ct.* from tblCenterTrans ct WHERE ct.EmiratesId =@emiratesId and ct.LangId =@langId and ct.IsDeleted=0;";


            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = await _conn.QueryMultipleAsync(query, new { @emiratesId = emiratesId, @langId = langId }).ConfigureAwait(false);
                var centers = result.Read<Centers>().ToList();
                var emirates = result.Read<Emirates>().ToList();
                var centerTrans = result.Read<CenterTrans>().ToList();

                var output = (from c in centers
                              select new Centers
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  LocationAddress = c.LocationAddress,
                                  EmiratesId = c.EmiratesId,
                                  TradeLicense = c.TradeLicense,
                                  Longitude = c.Longitude,
                                  Latitude = c.Latitude,
                                  IsActive = c.IsActive,
                                  IsDeleted = c.IsDeleted,
                                  CreatedOn = c.CreatedOn,
                                  CreatedBy = c.CreatedBy,
                                  UpdatedBy = c.UpdatedBy,
                                  UpdatedOn = c.UpdatedOn,
                                  TradeLicenseExpiryDate = c.TradeLicenseExpiryDate,
                                  FaxNo = c.FaxNo,
                                  PhoneNo = c.PhoneNo,
                                  WebSite = c.WebSite,
                                  Email = c.Email,
                                  Emirates = (from e in emirates
                                              where e.Id == c.EmiratesId
                                              select e).FirstOrDefault(),
                                  CenterTranslation = (from ct in centerTrans
                                                       where ct.CenterId == c.Id
                                                       select ct).ToList()
                              }).ToList();
                return output;
            }
        }

        public int UpdateCenter(Centers center)
        {
            center.UpdatedOn = DateTime.Now;
            return base.Update(center);
        }

        public Centers GetCenterByName(string centerName, Int64 emiratesId)
        {

            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblCenters c WHERE c.Name=@centerName and c.EmiratesId =@emiratesId and c.IsDeleted=0";
                var result = _conn.Query<Centers>(query, new { @centerName = centerName, @emiratesId = emiratesId });
                return result.FirstOrDefault();
            }

        }
    }
}
