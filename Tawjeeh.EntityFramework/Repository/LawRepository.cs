using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityFramework.Interface;
using System.Linq.Expressions;
using Tawjeeh.EntityFramework.Helper;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ILawRepository{Tawjeeh.EntityModel.Law}" />
    public class LawRepository : RepositoryBase<TawjeehContext>,
        ILawRepository<Law>
    {
        /// <summary>
        /// Inserts the or update law.
        /// </summary>
        /// <param name="laws">The laws.</param>
        /// <returns></returns>
        public int InsertOrUpdateLaw(Law laws)
        {
            return InsertOrUpdate(laws);
        }

        /// <summary>
        /// Deletes the law.
        /// </summary>
        /// <param name="laws">The laws.</param>
        /// <returns></returns>
        public int DeleteLaw(Law laws)
        {
            var output = 0;            
            var context = new TawjeehContext();
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Configuration.AutoDetectChangesEnabled = false;
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {

                    var lawtrans = laws.LawTranslations.DefaultIfEmpty().ToList();
                    var articles = laws.Articles.DefaultIfEmpty().ToList();

                    if (articles.Count > 0)
                    {
                        var artTrans = articles.SelectMany(x => x.ArticleTranslations).DefaultIfEmpty().ToList();
                        var artMultimedia = articles.SelectMany(x => x.MultimediaArticles)
                                                    .DefaultIfEmpty().ToList();
                        var decisions = articles.SelectMany(x => x.Decisions)
                                                    .DefaultIfEmpty().ToList();
                        var decisionstrans = articles.SelectMany(x => x.Decisions.SelectMany(y => y.DecisionTranslations)).DefaultIfEmpty().ToList();
                        var decisionmultimedia = articles.SelectMany(x => x.Decisions.SelectMany(y => y.MultimediaDecisions)).DefaultIfEmpty().ToList();

                        context = PerformBatchDelete(context, artTrans);
                        context = PerformBatchDelete(context, artMultimedia);
                        context = PerformBatchDelete(context, decisions);
                        context = PerformBatchDelete(context, decisionstrans);
                        context = PerformBatchDelete(context, decisionmultimedia);
                        context = PerformBatchDelete(context, articles);
                    }                   
                    context = PerformBatchDelete(context, lawtrans);
                    context = BatchSoftDelete(context, laws);
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
            context.Configuration.ValidateOnSaveEnabled = true;
            return output;
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Law> GetAll(int langId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Law> GetAll()
        {
            var result = GetAllQuery<Law>(@"Articles,
                                            Articles.Decisions,
                                            Articles.MultimediaArticles,
                                            Articles.Decisions.MultimediaDecisions");
            return result;
        }
        /// <summary>
        /// Gets the law by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Law GetLawById(long id)
        {
            var lawsearch = Query<Law>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(lawsearch, "LawTranslations");
        }
        /// <summary>
        /// Gets the law identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Law GetLawId(long id)
        {
            var lawsearch = Query<Law>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(lawsearch, @"Articles,
                                                         Articles.ArticleTranslations,
                                                         Articles.Decisions,
                                                         Articles.Decisions.DecisionTranslations,
                                                         Articles.MultimediaArticles,
                                                         Articles.Decisions.MultimediaDecisions");
        }
        /// <summary>
        /// Gets the law by identifier and language identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public Law GetLawByIdAndLangId(long id, int langId)
        {
            var lawsearch = Query<Law>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(lawsearch, "LawTranslations");
        }

        /// <summary>
        /// Gets the name of the law by.
        /// </summary>
        /// <param name="lawName">Name of the law.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Law GetLawByName(string lawName)
        {
            throw new NotImplementedException();
        }      
    }
}
