using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ICampaignRepository{Tawjeeh.EntityModel.Campaign}" />
    public class CampaignRepository : RepositoryBase<TawjeehContext>,
               ICampaignRepository<Campaign>
    {
        /// <summary>
        /// Deletes the campaign.
        /// </summary>
        /// <param name="camp">The camp.</param>
        /// <returns></returns>
        public int DeleteCampaign(Campaign camp)
        {
            var output = 0;
            var context = new TawjeehContext();
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {
                    var goal = camp.Goals.DefaultIfEmpty().ToList();
                    var initiativeCamp = camp.InitiativeCampaigns.DefaultIfEmpty().ToList();
                    var campDetails = camp.CampaignDetails.DefaultIfEmpty().ToList();
                    var campdoc = camp.CampaignDetails.SelectMany(x => x.CampaignDocuments).DefaultIfEmpty().ToList();

                    context = PerformBatchDelete(context, goal);
                    context = PerformBatchDelete(context, initiativeCamp);
                    context = PerformBatchDelete(context, campDetails);
                    context = PerformBatchDelete(context, campdoc);
                    context = BatchSoftDelete(context, camp);

                    output = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    output = 0;
                }
                finally
                {
                    if (output != 0)
                    {
                        ts.Commit();
                    }
                    else
                    {
                        ts.Rollback();

                    }
                    ts.Dispose();
                }
            }
            return output;
        }

        /// <summary>
        /// Gets the campaign by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<Campaign> GetCampaignById(long id)
        {
            var search = Query<Campaign>.Create(x => x.Id == id);

            return GetAllQueryDisposable(search, @"CampaignDetails,
                                                Goals,
                                                CampaignDetails.CampaignDocuments,
                                                InitiativeCampaigns,
                                                InitiativeCampaigns.Initiative").AsEnumerable();        }
        /// <summary>
        /// Gets the campaign multimedias.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<CampaignMultimedia> GetCampaignMultimedias(long id)
        {
            object[] param = { new SqlParameter("@campaignId", id) };
            var result = GetStoreListDisposableContext<CampaignMultimedia>("spGetMultimediaCampaign @campaignId", param);
            return result.AsEnumerable();
        }
        /// <summary>
        /// Gets the campaigns.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Campaign> GetCampaigns()
        {
            return GetAllIncludeQuery<Campaign>(@"CampaignDetails,
                                                Goals,
                                                CampaignDetails.CampaignDocuments,
                                                InitiativeCampaigns,
                                                InitiativeCampaigns.Initiative").AsEnumerable();
        }
        /// <summary>
        /// Inserts the or update campaing.
        /// </summary>
        /// <param name="camp">The camp.</param>
        /// <returns></returns>
        public int InsertOrUpdateCampaing(Campaign camp)
        {
            var output = 0;
            var context = new TawjeehContext();
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {
                    if (camp.Id != 0)
                    {                       
                        context.Campaign.Attach(camp);
                        context.Entry(camp).State = EntityState.Modified;

                        if (camp.CampaignDetails != null)                        
                            context = PerformInsertOrUpdate(context, camp.CampaignDetails.AsEnumerable());                            

                        if (camp.Goals != null)                                
                            context = PerformInsertOrUpdate(context, camp.Goals.AsEnumerable());
                    }
                    else
                    {
                        context.Campaign.Add(camp);
                        context.Entry(camp).State = EntityState.Added;

                        if (camp.CampaignDetails != null)                                               
                            context = PerformInsertOrUpdate(context, camp.CampaignDetails.AsEnumerable());
                        
                        if (camp.Goals != null)
                            context = PerformInsertOrUpdate(context, camp.Goals.AsEnumerable());
                        
                    }

                    output = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    output = 0;
                }
                finally
                {
                    if (output != 0)
                    {
                        ts.Commit();
                    }
                    else
                    {
                        ts.Rollback();

                    }
                    ts.Dispose();
                }
            }
            return output;
        }
    }
}
