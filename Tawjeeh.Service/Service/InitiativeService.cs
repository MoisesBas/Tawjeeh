using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class InitiativeService : IInitiativeService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(InitiativeService));
        private IInitiativeCampaignRepository _initiativeCampaignRepo;
        private IInitiativeRepository _initiativeRepo;
        private IInitiativeTypeRepository _initiativeTypeRepo;

        public InitiativeService(IInitiativeCampaignRepository initiativeCampaignRepo,
            IInitiativeRepository initiativeRepo,
            IInitiativeTypeRepository initiativeTypeRepo)
        {
            Guard.NotNull(initiativeCampaignRepo, nameof(initiativeCampaignRepo));
            Guard.NotNull(initiativeRepo, nameof(initiativeRepo));
            Guard.NotNull(initiativeTypeRepo, nameof(initiativeTypeRepo));

            _initiativeCampaignRepo = initiativeCampaignRepo;
            _initiativeRepo = initiativeRepo;
            _initiativeTypeRepo = initiativeTypeRepo;

        }
        public int CreateInitiative(Initiative initiative)
        {
            var intInitiative = 0;
            Utilities.Try(() =>
            {
                using (var transaction = new TransactionScope())
                {
                    Guard.NotNull(initiative, nameof(initiative));
                    intInitiative = _initiativeRepo.CreateInitiative(initiative);
                    if (intInitiative == 0) throw new Exception("Unable to add Initiative.,");

                    if (initiative.InitiativeCampaign != null)
                    {
                        if (initiative.InitiativeCampaign.Count > 0)
                        {
                            initiative.InitiativeCampaign.ToList().ForEach(x =>
                            {
                                Guard.NotDefault(x.CampaignId, "Campaign Id is null.,");
                                x.InitiativeId = intInitiative;
                                if (x.Id != 0) _initiativeCampaignRepo.UpdateInitiativeCampaign(x);
                                _initiativeCampaignRepo.CreateInitiativeCampaign(x);
                            });
                        }
                    }

                    if (intInitiative > 0)
                    {
                        transaction.Complete();
                        transaction.Dispose();
                    }
                }
            }, "CreateInitiative(Initiative initiative)",
            log);

            return intInitiative;
        }

        public int CreateInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {            
            return _initiativeCampaignRepo.CreateInitiativeCampaign(initiativeCampaign);
        }

        public int CreateInitiativeType(InitiativeType initiativeType)
        {
            return _initiativeTypeRepo.CreateInitiativeType(initiativeType);
        }

        public int DeleteInitiative(Int64 iniId)
        {
            return _initiativeRepo.DeleteInitiative(iniId);
        }

        public int DeleteInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {
            return _initiativeCampaignRepo.DeleteInitiativeCampaign(initiativeCampaign);
        }

        public int DeleteInitiativeType(InitiativeType initiativeType)
        {
            return _initiativeTypeRepo.DeleteInitiativeType(initiativeType);
        }

        public IList<Initiative> GetInitiativeAll()
        {
            return _initiativeRepo.GetAll();
        }

        public IList<InitiativeCampaign> GetInitiativeCampaignByCampaignId(int campId)
        {
            return _initiativeCampaignRepo.GetInitiativeCampaignByCampaignId(campId);
        }

        public Initiative GetInitiativeById(long id)
        {
            return _initiativeRepo.GetInitiativeById(id);
        }
        

        public Task<IEnumerable<InitiativeCampaign>> GetInitiativeCampaignAll()
        {
            return _initiativeCampaignRepo.GetAll();
        }

        public InitiativeCampaign GetInitiativeCampaignById(int id)
        {
            return _initiativeCampaignRepo.GetInitiativeCampaignById(id);
        }

        public Task<IEnumerable<InitiativeType>> GetInitiativeTypeAll()
        {
            return _initiativeTypeRepo.GetAll();
        }

        public InitiativeType GetInitiativeTypeById(int id)
        {
            return _initiativeTypeRepo.GetInitiativeTypeById(id);
        }

        public int UpdateInitiative(Initiative initiative)
        {
            var output = 0;

            Guard.NotNull(initiative, nameof(initiative));
            Guard.NotDefault(initiative.Id,"Initiative Id is null.,");
            output = _initiativeRepo.UpdateInitiative(initiative);

            var init = _initiativeRepo.GetInitiativeById(initiative.Id);
            Guard.NotNull(init, "Initiative is not exists");

            if (initiative.InitiativeCampaign != null)
            {
                if (initiative.InitiativeCampaign.Count > 0)
                {
                    initiative.InitiativeCampaign.ToList().ForEach(x =>
                    {
                        Guard.NotDefault(x.CampaignId, "Campaign Id is null.,");
                        x.InitiativeId = init.Id;
                        output = x.Id == 0 ? _initiativeCampaignRepo.CreateInitiativeCampaign(x) :
                         _initiativeCampaignRepo.UpdateInitiativeCampaign(x);
                    });
                }
            }
            return output;
            
        }

        public int UpdateInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {
            return _initiativeCampaignRepo.UpdateInitiativeCampaign(initiativeCampaign);
        }

        public int UpdateInitiativeType(InitiativeType initiativeType)
        {
            return _initiativeTypeRepo.UpdateInitiativeType(initiativeType);
        }

        public IList<Initiative> GetInitiativeByCampaignId(int campId)
        {
            return _initiativeRepo.GetInitiativeByCampaignId(campId);
        }
    }
}
