using log4net;
using System;
using System.Collections.Generic;
using System.Transactions;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;
using System.Linq;

namespace Tawjeeh.Service.Service
{
   public class CampaignService: ICampaignService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CampaignService));
        private ICampaignRepository _campaignRepo;
        private ICampaignDetailsRepository _campaignDetailsRepo;
        private IGoalRepository _goalRepo;
        private ICampaignDocumentRepository _campDocRepo;

        public CampaignService(ICampaignRepository campaignRepo, 
            ICampaignDetailsRepository campaignDetailsRepo,
            IGoalRepository goalRepo,
            ICampaignDocumentRepository campDocRepo)
        {
            Guard.NotNull(campaignRepo, nameof(campaignRepo));
            Guard.NotNull(campaignDetailsRepo, nameof(campaignDetailsRepo));
            Guard.NotNull(goalRepo, nameof(goalRepo));
            Guard.NotNull(campDocRepo, nameof(campDocRepo));
            _campaignRepo = campaignRepo;
            _campaignDetailsRepo = campaignDetailsRepo;
            _goalRepo = goalRepo;
            _campDocRepo = campDocRepo;
        }

        public int CreateCampaign(Campaign camp)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                Guard.NotNull(camp, nameof(camp));

                using (var transaction = new TransactionScope())
                {
                    var intCamp = _campaignRepo.CreateCampaign(camp);
                    if (intCamp == 0) throw new Exception("Unable to Create Campaign.,");
                    if (camp.CampaignDetails != null)
                    {
                        if (camp.CampaignDetails.Count > 0)
                        {
                            foreach (var c in camp.CampaignDetails)
                            {
                                c.CampaignId = intCamp;
                                _campaignDetailsRepo.CreateCampaignDetails(c);
                            }
                        }
                    }
                    if (camp.Goals != null)
                    {
                        if (camp.Goals.Count > 0)
                        {
                            foreach (var g in camp.Goals)
                            {
                                g.CampaignId = intCamp;
                                _goalRepo.CreateGoal(g);
                            }

                        }
                    }
                    output = intCamp;
                    if (output != 0) transaction.Complete();
                    transaction.Dispose();
                    
                }
            }, "CreateCampaign(Campaign camp)", log);
            return output;
        }

        public int DeleteCampaign(Campaign camp)
        {           
            return _campaignRepo.DeleteCampaign(camp);            
        }

        public Campaign GetCampaignById(long campaignId)
        {
            var campaign = _campaignRepo.GetCampaignById(campaignId);
            if (campaign != null)
            {
                var multimedia = _campDocRepo.GetCampaignMultimedia(campaign.Id);
                if (multimedia.Count() > 0)
                {                    
                    multimedia.ToList().ForEach(x =>
                    {                      
                       
                        campaign.CampaignMultimedia.Add(x);
                        });
                    };
                }
               
            
            return campaign;
        }

        public IList<Campaign> GetCampaignAll()
        {
            return _campaignRepo.GetCampaigns();
        }

        public int UpdateCampaign(Campaign camp)
        {
            var output = 0;
            Utilities.Try(() =>
            {
                using (var transaction = new TransactionScope())
                {
                    Guard.NotDefault(camp.Id, "Campaign Id is null");
                    var intCamp = _campaignRepo.GetCampaignById(Convert.ToInt64(camp.Id));
                    if (intCamp == null) throw new Exception("Unable to Update Campaign.,");
                    var isUpdate = _campaignRepo.UpdateCampaign(camp);
                    if (isUpdate != 0)
                    {
                        if (camp.CampaignDetails != null)
                        {
                            if (camp.CampaignDetails.Count > 0)
                            {
                                foreach (var c in camp.CampaignDetails)
                                {
                                    c.CampaignId = Convert.ToInt64(intCamp.Id);
                                    var details = _campaignDetailsRepo.GetCampaignDetailsById(Convert.ToInt64(c.Id));
                                    if (details == null)
                                        _campaignDetailsRepo.CreateCampaignDetails(c);
                                    _campaignDetailsRepo.UpdateCampaignDetails(c);
                                }
                            }
                        }
                        if (camp.Goals != null)
                        {
                            if (camp.Goals.Count > 0)
                            {
                                foreach (var c in camp.Goals)
                                {
                                    c.CampaignId = Convert.ToInt64(intCamp.Id);
                                    var details = _goalRepo.GetGoalById(Convert.ToInt64(c.Id));
                                    if (details == null)
                                        _goalRepo.CreateGoal(c);
                                    _goalRepo.UpdateGoal(c);
                                }
                            }
                        }
                        output = Convert.ToInt32(intCamp.Id);
                    }
                    if (output != 0) transaction.Complete();
                    transaction.Dispose();
                }
            }, "UpdateCampaign(Campaign camp)", log);
            return output;
        }

        public int CreateCampaignDocument(CampaignDocument campDoc)
        {
            return _campDocRepo.CreateCampaignDocument(campDoc);
        }

        public int DeleteCampaignDocument(CampaignDocument campDoc)
        {
            return _campDocRepo.DeleteCampaignDocument(campDoc);
        }

        public int UpdateCampaignDocument(CampaignDocument campDoc)
        {
            return _campDocRepo.UpdateCampaignDocument(campDoc);
        }

        public IList<CampaignDocument> GetCampaignDocuments()
        {
            return _campDocRepo.GetCampaignDocuments();
        }
        public IList<CampaignDocument> GetCampaignMultimediaByCampaignId(int campId)
        {
            return _campDocRepo.GetCampaignDocuments(campId);
        }
        public CampaignDocument GetCampaignDocumentById(long id)
        {
            return _campDocRepo.GetCampaignDocumentById(id);
        }

        public int CreateCampaignDetails(CampaignDetails campDetails)
        {
            return _campaignDetailsRepo.CreateCampaignDetails(campDetails);
        }

        public int DeleteCampaignDetails(CampaignDetails campDetails)
        {
            campDetails.IsActive = true;
            campDetails.IsDeleted = true;
            campDetails.UpdatedOn = DateTime.Now;
            campDetails.UpdatedBy = 1;
            return _campaignDetailsRepo.UpdateCampaignDetails(campDetails);
        }


        public int UpdateCampaignDetails(CampaignDetails campDetails)
        {         
            campDetails.UpdatedOn = DateTime.Now;
            campDetails.UpdatedBy = 1;
            return _campaignDetailsRepo.UpdateCampaignDetails(campDetails);
        }

        public CampaignDetails GetCampaignDetails(long campId, int type, long subTypeId)
        {
            return _campaignDetailsRepo.GetCampaignDetails(campId, type, subTypeId);
        }

        public IList<CampaignMultimedia> GetCampaignMultimedia(long campId)
        {
            return _campDocRepo.GetCampaignMultimedia(campId);
        }

        public CampaignDetails GetCampaignDetailsById(long id)
        {
            return _campaignDetailsRepo.GetCampaignDetailsById(id);
        }

        public CampaignDetails GetCampaignDetailsByCampaignId(long campaignId)
        {
            return _campaignDetailsRepo.GetCampaignDetailsByCampaignId(campaignId);
        }
    }
}
