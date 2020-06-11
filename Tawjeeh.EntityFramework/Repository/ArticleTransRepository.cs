
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using System.Linq;
using System;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IArticleTransRepository{Tawjeeh.EntityModel.ArticleTrans}" />
    public class ArticleTransRepository : RepositoryBase<TawjeehContext>,
         IArticleTransRepository<ArticleTrans>
    {

        /// <summary>
        /// Deletes the article trans.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public int DeleteArticleTrans(ArticleTrans article)
        {
            var output = 0;
            var context = new TawjeehContext();
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Configuration.AutoDetectChangesEnabled = false;
            using (var ts = context.Database.BeginTransaction())
            {
                try
                {
                    var articletrans = article.Article.MultimediaArticles.DefaultIfEmpty().ToList();
                    if (articletrans.Count > 0)
                    {           
                        context = PerformBatchDelete(context, articletrans);                        
                    }                   
                    context = BatchSoftDelete(context, article);
                    output = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    output = 0;
                }
                finally
                {
                    if (output != 0) ts.Commit();
                    ts.Rollback();                    
                    ts.Dispose();
                }
            }
            context.Configuration.ValidateOnSaveEnabled = true;
            return output;
        }

        /// <summary>
        /// Gets the multimedia top video.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public IEnumerable<ArticleTrans> GetMultimediaTopVideo(int langId)
        {
            var search = Query<ArticleTrans>.Create(x => x.LangId == langId);
            return GetAllQueryDisposable(search, @"Article,
                                                   Article.MultimediaArticles").AsEnumerable();
        }
        /// <summary>
        /// Gets the article all trans.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IEnumerable<ArticleTrans>> GetArticleAllTrans()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the article by language identifier.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public IEnumerable<ArticleTrans> GetArticleByLangId(int langId)
        {
            var search = Query<ArticleTrans>.Create(x => x.LangId == langId);
            return GetAllQueryDisposable(search, @"Article,
                                                   Article.MultimediaArticles,
                                                   Article.Decisions,
                                                   Article.Decisions.DecisionTranslations,
                                                   Article.Decisions.MultimediaDecisions").AsEnumerable();
        }

        /// <summary>
        /// Gets the article by law identifier and language identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ArticleTrans> GetArticleByLawIdAndLangId(long lawId, int langId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the article language identifier and article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public ArticleTrans GetArticleLangIdAndArticleId(long articleId, int langId)
        {
            var articleSearch = Query<ArticleTrans>.Create(x => x.ArticleId == articleId && x.LangId == langId);
            return FirstOrDefaultDisposable(articleSearch);
        }

        /// <summary>
        /// Gets the article trans by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ArticleTrans GetArticleTransById(long id)
        {
            var articleSearch = Query<ArticleTrans>.Create(x => x.Id == id);
            return FirstOrDefaultDisposable(articleSearch);
        }
        /// <summary>
        /// Inserts the update article trans.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public int InsertUpdateArticleTrans(ArticleTrans article)
        {
            return InsertUpdateArticleTrans(article);
        }

        
    }
}
