using System;
using System.Collections.Generic;
using System.Data.Entity;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using System.Linq;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IInitiativeRepository{Tawjeeh.EntityModel.Initiative}" />
    public class InitiativeRepository : RepositoryBase<TawjeehContext>,
            IInitiativeRepository<Initiative>
    {
        /// <summary>
        /// Deletes the initiative.
        /// </summary>
        /// <param name="initiative">The initiative.</param>
        /// <returns></returns>
        public int DeleteInitiative(Initiative initiative)
        {
            var output = 0;
            var context = new TawjeehContext();
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {
                   
                    var initiativeCamp = initiative.InitiativeCampaigns.DefaultIfEmpty().ToList();
                    context = PerformBatchDelete(context, initiativeCamp);                   
                    context = BatchSoftDelete(context, initiative);
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
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Initiative> GetAll()
        {
            return GetListDisposableContext<Initiative>();
        }

        /// <summary>
        /// Gets the initiative by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Initiative GetInitiativeById(long id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Inserts the or update initiative.
        /// </summary>
        /// <param name="initiative">The initiative.</param>
        /// <returns></returns>
        public int InsertOrUpdateInitiative(Initiative initiative)
        {
            var output = 0;
            var context = new TawjeehContext();
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {
                    if (initiative.Id != 0)
                    {
                        context.Initiative.Attach(initiative);
                        context.Entry(initiative).State = EntityState.Modified;

                        if (initiative.InitiativeCampaigns != null)
                        {
                            context = PerformInsertOrUpdate(context, initiative.InitiativeCampaigns.AsEnumerable());
                        }
                    }
                    else
                    {
                        context.Initiative.Add(initiative);
                        context.Entry(initiative).State = EntityState.Added;
                        if (initiative.InitiativeCampaigns != null)
                        {
                            context = PerformInsertOrUpdate(context, initiative.InitiativeCampaigns.AsEnumerable());
                        }

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
