using System.Collections.Generic;
using System.Linq;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IInitiativeService" />
    public class InitiativeService: IInitiativeService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="InitiativeService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public InitiativeService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        /// <summary>
        /// Deletes the initiative.
        /// </summary>
        /// <param name="iniId">The ini identifier.</param>
        /// <returns></returns>
        public int DeleteInitiative(long iniId)
        {
            var result = _repositoryFactory.GetInitiativeRepository.GetInitiativeById(iniId);
            return _repositoryFactory.GetInitiativeRepository.DeleteInitiative(result);
        }
        /// <summary>
        /// Gets the initiative by campaign identifier.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        public IEnumerable<Initiative> GetInitiativeByCampaignId(int campId)
        {
            var result =  _repositoryFactory.GetInitiativeCampaignRepository.GetInitiativeCampaignByCampaignId(campId);
            var output = (from r in result
                          let i = r.Initiative
                          select new Initiative()
                          {
                              Id = i.Id,
                              InitiativeTypeId = i.InitiativeTypeId,
                              InitiativeType = i.InitiativeType,
                              IsActive = i.IsActive,
                              IsDeleted = i.IsDeleted,
                              CreatedBy = i.CreatedBy,
                              CreatedOn = i.CreatedOn,
                              UpdatedBy = i.UpdatedBy,
                              UpdatedOn = i.UpdatedOn,
                              Title = i.Title,
                              Description = i.Description,
                              InitiativeCampaigns = i.InitiativeCampaigns
                          }).AsEnumerable();

            return output;
        }
        /// <summary>
        /// Gets the initiative campaign by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public InitiativeCampaign GetInitiativeCampaignById(int id)
        {
            return _repositoryFactory.GetInitiativeCampaignRepository.GetInitiativeCampaignById(id);
        }
        /// <summary>
        /// Inserts the or update initiative.
        /// </summary>
        /// <param name="initiative">The initiative.</param>
        /// <returns></returns>
        public int InsertOrUpdateInitiative(Initiative initiative)
        {
            return _repositoryFactory.GetInitiativeRepository.InsertOrUpdateInitiative(initiative);
        }
        /// <summary>
        /// Inserts the or update initiative campaign.
        /// </summary>
        /// <param name="initiativeCamp">The initiative camp.</param>
        /// <returns></returns>
        public int InsertOrUpdateInitiativeCampaign(InitiativeCampaign initiativeCamp)
        {
            return _repositoryFactory.GetInitiativeCampaignRepository.InsertOrUpdateInitiativeCampaign(initiativeCamp);
        }
    }
}
