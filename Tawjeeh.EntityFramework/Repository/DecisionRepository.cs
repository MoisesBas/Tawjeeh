using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IDecisionRepository{Tawjeeh.EntityModel.Decision}" />
    public class DecisionRepository : RepositoryBase<TawjeehContext>,
   IDecisionRepository<Decision>
    {
        /// <summary>
        /// Inserts the or update decision.
        /// </summary>
        /// <param name="decision">The decision.</param>
        /// <returns></returns>
        public int InsertOrUpdateDecision(Decision decision)
        {
            return InsertOrUpdate(decision);
        }
        /// <summary>
        /// Deletes the decision.
        /// </summary>
        /// <param name="decision">The decision.</param>
        /// <returns></returns>
        public int DeleteDecision(Decision decision)
        {
            var output = 0;
            var context = new TawjeehContext();
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Configuration.AutoDetectChangesEnabled = false;
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {
                    var decisionstrans = decision.DecisionTranslations.DefaultIfEmpty().ToList();
                    var decisionMultimedias = decision.MultimediaDecisions.DefaultIfEmpty().ToList();
                    context = PerformBatchDelete(context, decisionstrans);
                    context = PerformBatchDelete(context, decisionMultimedias);
                    context = BatchSoftDelete(context, decision);
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
        /// Gets the decision all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Decision> GetDecisionAll()
        {
            return GetAllIncludeQuery<Decision>(@"DecisionTranslations,
                                                  MultimediaDecisions")
                                                .AsEnumerable();
        }
        /// <summary>
        /// Gets the decision by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Decision GetDecisionById(long id)
        {
            var decisionsearch = Query<Decision>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(decisionsearch, @"DecisionTranslations,                                                         
                                                                  MultimediaDecisions");
        }
        /// <summary>
        /// Gets the decision all.
        /// </summary>
        /// <param name="articleIds">The article ids.</param>
        /// <returns></returns>
        public Tuple<IEnumerable<Decision>> GetDecisionAll(long[] articleIds)
        {
            return new Tuple<IEnumerable<Decision>>(GetAllQuery<Decision>()
                                    .Where(x => articleIds.Contains(x.ArticleId.Value))
                                      .AsEnumerable());
        }
        /// <summary>
        /// Gets the decision by article identifier and language identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public IEnumerable<Decision> GetDecisionByArticleIdAndLangId(long articleId)
        {
            var decisionsSearch = Query<Decision>.Create(x => x.ArticleId == articleId);
            var result = GetAllQueryDisposable(decisionsSearch, @"DecisionTranslations,
                                                                   MultimediaDecisions,
                                                                   Article,
                                                                   Article.ArticleTranslations,
                                                                   Article.Law,
                                                                   Article.Law.LawTranslations");
            return result;
        }
        /// <summary>
        /// Gets the decision alls.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Decision> GetDecisionAlls()
        {
            return GetAllIncludeQuery<Decision>()
                               .Include("DecisionTranslations")
                               .Include("Article")
                               .Include("Article.Law")
                               .Include("MultimediaDecisions")
                               .AsEnumerable();          
        }
    }
}
