using System.Collections.Generic;
using System.Linq;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;
using Tawjeeh.EntityServices.Interface;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.ICampaignService" />
    public class CampaignService : ICampaignService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public CampaignService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Deletes the campaign.
        /// </summary>
        /// <param name="camp">The camp.</param>
        /// <returns></returns>
        public int DeleteCampaign(Campaign camp)
        {
            var result = _repositoryFactory.GetCampaignRepository.GetCampaignById(camp.Id).FirstOrDefault();
            return _repositoryFactory.GetCampaignRepository.DeleteCampaign(result);
        }

        /// <summary>
        /// Gets the campaign all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CampaignReadOnly> GetCampaignAll()
        {
            var result = _repositoryFactory.GetCampaignRepository.GetCampaigns().ToList();
            var output = (from r in result
                          let details = r?.CampaignDetails
                          let document = details != null ? r.CampaignDetails.SelectMany(x => x.CampaignDocuments) : null
                          let initiative = r.InitiativeCampaigns.Select(x => x.Initiative).FirstOrDefault()
                          let goal = r?.Goals
                          select new CampaignReadOnly
                          {
                              Id = r.Id,
                              Title = r.Title,
                              FromDate = r.FromDate,
                              ToDate = r.ToDate,
                              Target = r.Target,
                              Budget = r.Budget,
                              CampaignDetails = details,
                              Goals = goal,
                              CampaignDocument = document,
                              Initiative = initiative,
                              CampaignStatus = r.CampaignStatus,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                              CreatedBy = r.CreatedBy,
                              CreatedOn = r.CreatedOn,
                              UpdatedBy = r.UpdatedBy,
                              UpdatedOn = r.UpdatedOn                             
                          }).AsEnumerable();
            return output;

        }
        /// <summary>
        /// Gets the campaign by identifier.
        /// </summary>
        /// <param name="campaignId">The campaign identifier.</param>
        /// <returns></returns>
        public CampaignReadOnly GetCampaignById(long campaignId)
        {
          var result =  _repositoryFactory.GetCampaignRepository.GetCampaignById(campaignId);
          var multimedia = _repositoryFactory.GetCampaignRepository.GetCampaignMultimedias(campaignId);
          var output = (from r in result
                          let details = r?.CampaignDetails
                          let document = details != null ? r.CampaignDetails.SelectMany(x => x.CampaignDocuments) : null
                          let initiative = r.InitiativeCampaigns.Select(x => x.Initiative).FirstOrDefault()
                          let goal = r?.Goals
                          select new CampaignReadOnly
                          {
                              Id = r.Id,
                              Title = r.Title,
                              FromDate = r.FromDate,
                              ToDate = r.ToDate,
                              Target = r.Target,
                              Budget = r.Budget,
                              CampaignDetails = details,
                              Goals = goal,
                              CampaignDocument = document,
                              Initiative = initiative,
                              CampaignStatus = r.CampaignStatus,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                              CreatedBy = r.CreatedBy,
                              CreatedOn = r.CreatedOn,
                              UpdatedBy = r.UpdatedBy,
                              UpdatedOn = r.UpdatedOn,
                              CampaignMultimedia = multimedia
                          }).FirstOrDefault();
            return output;
        }
        /// <summary>
        /// Gets the campaign details by campaign identifier.
        /// </summary>
        /// <param name="campaignId">The campaign identifier.</param>
        /// <returns></returns>
        public CampaignDetail GetCampaignDetailsByCampaignId(long campaignId)
        {
            return _repositoryFactory.GetCampaignDetailsRepository.GetCampaignDetailsByCampaignId(campaignId);
        }
        /// <summary>
        /// Gets the campaign multimedia.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        public IEnumerable<CampaignMultimedia> GetCampaignMultimedia(long campId)
        {
            return _repositoryFactory.GetCampaignRepository.GetCampaignMultimedias(campId);
        }
        /// <summary>
        /// Inserts the or update campaign.
        /// </summary>
        /// <param name="camp">The camp.</param>
        /// <returns></returns>
        public int InsertOrUpdateCampaign(Campaign camp)
        {
            return _repositoryFactory.GetCampaignRepository.InsertOrUpdateCampaing(camp);
        }
        /// <summary>
        /// Inserts the or update campaign document.
        /// </summary>
        /// <param name="campDoc">The camp document.</param>
        /// <returns></returns>
        public int InsertOrUpdateCampaignDoc(CampaignDocument campDoc)
        {
            return _repositoryFactory.GetCampaignDocumentRepository.InsertOrUpdateCampaignDocument(campDoc);
        }

       
    }
}
