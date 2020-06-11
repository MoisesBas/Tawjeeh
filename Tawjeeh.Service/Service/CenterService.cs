using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using log4net;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class CenterService : ICenterService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CenterService));
        private ICenterRepository _centerRepo;
        private IUserRepository _userRepo;
        private IContactRepository _centerContactRepo;
        private ICenterTransRepository _centerTransRepo;

        public CenterService(ICenterRepository centerRepo, 
                             IUserRepository userRepo, 
                             IContactRepository centerContactRepo, 
                             ICenterTransRepository centerTransRepo)
        {
            Guard.NotNull(centerRepo, nameof(centerRepo));
            Guard.NotNull(userRepo, nameof(userRepo));
            Guard.NotNull(centerContactRepo, nameof(centerContactRepo));
            Guard.NotNull(centerTransRepo, nameof(centerTransRepo));
            _centerRepo = centerRepo;
            _userRepo = userRepo;
            _centerContactRepo = centerContactRepo;
            _centerTransRepo = centerTransRepo;
        }
        public int UpdateCenter(Centers center)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                output = _centerRepo.UpdateCenter(center);

            }, "UpdateCenter(Centers center)", log);
            return output;
        }
        public int CreateCenter(Centers center)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                Guard.NotNullOrEmpty(center.Name, "Name of Center is required.,");
                Guard.NotNullOrEmpty(center.LocationAddress, "Address of Centers is required.,");
                using (var transaction = new TransactionScope())
                {
                    var cent = _centerRepo.GetCenterByName(center.Name,center.EmiratesId);
                    if (cent == null)
                    {
                        var centOut = _centerRepo.CreateCenter(center);
                        if (centOut == 0)
                            throw new Exception("Unable to Add Centers");
                        output = centOut;
                    }
                    else
                    {
                        throw new Exception("Unable to add centers with the same emirates.,");
                    }
                    transaction.Complete();
                    transaction.Dispose();
                }
            }, "CreateCenter(Centers center)", log);

            return output;
        }
        public int DeleteCenter(Centers center)
        {
            int output = 0;
            Utilities.Try(() =>
            {
                using (var trans = new TransactionScope())
                {
                    var contact = _centerContactRepo.GetCenterContactByCenterId(center.Id);
                    if (contact.Count() > 0)
                    {
                        foreach (var c in contact)
                        {
                            c.IsDeleted = false;
                            c.IsActive = true;
                            var ct = _centerContactRepo.ContactUpdate(c);
                            if (ct > 0)
                            {
                                var user = _userRepo.GetUserById(Convert.ToInt32(c.UserId));
                                if (user != null)
                                {
                                    user.IsActive = true;
                                    user.IsDeleted = false;
                                    _userRepo.Update(user);
                                }
                            }
                            else
                            {
                                throw new Exception("Unable to delete center with contacts.,");
                            }
                        }
                    }
                    var centtrans = _centerTransRepo.GetCenterTransByCenterId(center.Id);
                    if(centtrans.Count > 0)
                    {
                        foreach(var t in centtrans)
                        {
                            t.IsActive = true;
                            t.IsDeleted = false;
                            _centerTransRepo.UpdateCenterTrans(t);
                        }
                    }
                    output = _centerRepo.DeleteCenter(center);
                    if (output == 0)
                    {
                        throw new Exception("Unable to delete centers.,");
                    }
                    else
                    { 
                        trans.Complete();
                        trans.Dispose();
                    }

                }
            }, "DeleteCenter(Centers center)", log);           
            return output;
        }
        public IEnumerable<Centers> GetAll(int langId)
        {
            return _centerRepo.GetAll(langId);
        }
        public IEnumerable<Centers> GetAll()
        {
            return _centerRepo.GetAll();
        }
        public Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId)
        {
            return _centerRepo.GetAllCentersByEmiratesId(emiratesId);
        }
        public Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId, int langId)
        {
            return _centerRepo.GetAllCentersByEmiratesId(emiratesId,langId);
        }
        public Centers GetCenterById(int id)
        {
            return _centerRepo.GetCenterById(id);
        }
        public Centers GetCenterById(int id, int langId)
        {
            return _centerRepo.GetCenterById(id, langId);
        }

        //translation
        public int CreateCenterTrans(CenterTrans centerTrans)
        {
            return _centerTransRepo.CreateCenterTrans(centerTrans);
        }
        public int DeleteCenterTrans(CenterTrans center)
        {
            return _centerTransRepo.DeleteCenterTrans(center);
        }
        public int UpdateCenterTrans(CenterTrans center)
        {
            return _centerTransRepo.UpdateCenterTrans(center);
        }
        public Task<IEnumerable<CenterTrans>> GetCenterTransAll()
        {
            return _centerTransRepo.GetCenterTransAll();
        }
        public CenterTrans GetCenterTransId(int id)
        {
            return _centerTransRepo.GetCenterTransId(id);
        }

      
    }
}
