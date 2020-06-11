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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ICampaignDetailsRepository{Tawjeeh.EntityModel.CampaignDetail}" />
    public class CampaignDetailsRepository : RepositoryBase<TawjeehContext>,
               ICampaignDetailsRepository<CampaignDetail>
    {
        /// <summary>
        /// Deletes the campaign details.
        /// </summary>
        /// <param name="campDetails">The camp details.</param>
        /// <returns></returns>
        public int DeleteCampaignDetails(CampaignDetail campDetails)
        {
            return DeleteRecord(campDetails);
        }

        /// <summary>
        /// Gets the campaign details.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CampaignDetail>> GetCampaignDetails()
        {
            return GetListDisposableContextAsync<CampaignDetail>();
        }

        /// <summary>
        /// Gets the campaign details.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="subTypeId">The sub type identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CampaignDetail GetCampaignDetails(long campId, int type, long subTypeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the campaign details by campaign identifier.
        /// </summary>
        /// <param name="campaignId">The campaign identifier.</param>
        /// <returns></returns>
        public CampaignDetail GetCampaignDetailsByCampaignId(long campaignId)
        {
            var search = Query<CampaignDetail>.Create(x => x.CampaignId == campaignId);
            return FirstOrDefaultDisposable(search);
        }

        /// <summary>
        /// Gets the campaign details by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CampaignDetail GetCampaignDetailsById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the or update campaign details.
        /// </summary>
        /// <param name="campDetails">The camp details.</param>
        /// <returns></returns>
        public int InsertOrUpdateCampaignDetails(CampaignDetail campDetails)
        {
            return InsertOrUpdate(campDetails);
        }
    }
}
