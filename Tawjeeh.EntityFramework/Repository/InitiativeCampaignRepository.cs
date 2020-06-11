using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IInitiativeCampaignRepository{Tawjeeh.EntityModel.InitiativeCampaign}" />
    public class InitiativeCampaignRepository : RepositoryBase<TawjeehContext>,
             IInitiativeCampaignRepository<InitiativeCampaign>
    {
        /// <summary>
        /// Deletes the initiative campaign.
        /// </summary>
        /// <param name="initiativeCampaign">The initiative campaign.</param>
        /// <returns></returns>
        public int DeleteInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {
            return DeleteRecord(initiativeCampaign);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<InitiativeCampaign>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the initiative campaign by campaign identifier.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        public IEnumerable<InitiativeCampaign> GetInitiativeCampaignByCampaignId(int campId)
        {
            var search = Query<InitiativeCampaign>.Create(x => x.CampaignId == campId);
            return GetAllQueryDisposable(search, @"Initiative,Initiative.InitiativeCampaigns").AsEnumerable();
        }

        /// <summary>
        /// Gets the initiative campaign by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public InitiativeCampaign GetInitiativeCampaignById(int id)
        {
            var articleSearch = Query<InitiativeCampaign>.Create(x => x.Id == id);
            return FirstOrDefaultDisposable(articleSearch);
        }

        /// <summary>
        /// Inserts the or update initiative campaign.
        /// </summary>
        /// <param name="initiativeCampaign">The initiative campaign.</param>
        /// <returns></returns>
        public int InsertOrUpdateInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {
            return InsertOrUpdate(initiativeCampaign);
        }
    }
}
