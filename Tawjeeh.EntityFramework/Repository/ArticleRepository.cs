
using System.Collections.Generic;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityFramework.Interface;
using System.Linq;
using System.Data.Entity;
using Tawjeeh.EntityFramework.Helper;
using System;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IArticleRepository{Tawjeeh.EntityModel.Article}" />
    public class ArticleRepository : RepositoryBase<TawjeehContext>,
        IArticleRepository<Article>
    {
        /// <summary>
        /// Inserts the update article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public int InsertUpdateArticle(Article article)
        {
            return InsertOrUpdate(article);
        }

        /// <summary>
        /// Deletes the article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public int DeleteArticle(Article article)
        {
            var output = 0;
            var context = new TawjeehContext();
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Configuration.AutoDetectChangesEnabled = false;
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {
                    var articletrans = article.ArticleTranslations.DefaultIfEmpty().ToList();
                    var artmultimedia = article.MultimediaArticles.DefaultIfEmpty().ToList();
                    var decisions = article.Decisions.DefaultIfEmpty().ToList();
                    var decisionstrans = article.Decisions.SelectMany(x => x.DecisionTranslations).DefaultIfEmpty().ToList();
                    var decisionMultimedias = article.Decisions.SelectMany(x => x.MultimediaDecisions).DefaultIfEmpty().ToList();

                    context = PerformBatchDelete(context, artmultimedia);
                    context = PerformBatchDelete(context, articletrans);
                    context = PerformBatchDelete(context, decisions);
                    context = PerformBatchDelete(context, decisionstrans);
                    context = PerformBatchDelete(context, decisionMultimedias);
                    context = BatchSoftDelete(context, article);
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
        /// Gets the article all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> GetArticleAll()
        {
            return GetListDisposableContext<Article>();
        }

        /// <summary>
        /// Gets the article all.
        /// </summary>
        /// <param name="articleIds">The article ids.</param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticleAll(long[] articleIds)
        {
            return GetAllIncludeQuery<Article>().Where(x => articleIds.Contains(x.Id))
                               .Include("Decisions")
                               .Include("Decisions.DecisionMultimedias")
                               .Include("MultimediaArticles")
                               .AsEnumerable();
        }

        /// <summary>
        /// Gets the article by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Article GetArticleById(long id)
        {
            var lawsearch = Query<Article>.Create("Id", OperationType.EqualTo, id);
            return FirstOrDefaultDisposable(lawsearch, @"ArticleTranslations,
                                                         Decisions,
                                                         Decisions.DecisionTranslations,
                                                         MultimediaArticles,
                                                         Decisions.MultimediaDecisions");
        }

        /// <summary>
        /// Gets the article by law identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticleByLawId(long lawId)
        {
            var articleSearch = Query<Article>.Create(x => x.LawId == lawId);
            return GetAllQueryDisposable(articleSearch, @"Decisions,
                                                MultimediaArticles,
                                                ArticleTranslations").AsEnumerable();
        }     

        
    }
}
