using System;
using System.Collections.Generic;
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
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IArticleMultimediaRepository{Tawjeeh.EntityModel.ArticleMultimedia}" />
    public class ArticleMultimediaRepository: RepositoryBase<TawjeehContext>,
        IArticleMultimediaRepository<ArticleMultimedia>
    {

        /// <summary>
        /// Deletes the article multimedia.
        /// </summary>
        /// <param name="articlemultimedia">The articlemultimedia.</param>
        /// <returns></returns>
        public int DeleteArticleMultimedia(ArticleMultimedia articlemultimedia)
        {
            return DeleteRecord(articlemultimedia);
        }

        /// <summary>
        /// Gets the article multimedia by article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public IEnumerable<ArticleMultimedia> GetArticleMultimediaByArticleId(long articleId)
        {
            return GetAllQuery<ArticleMultimedia>().Where(x => x.ArticleId == articleId).AsEnumerable();
        }

        /// <summary>
        /// Gets the article multimedia by article ids.
        /// </summary>
        /// <param name="articleIds">The article ids.</param>
        /// <returns></returns>
        public Tuple<IEnumerable<ArticleMultimedia>> GetArticleMultimediaByArticleIds(long[] articleIds)
        {
            return new Tuple<IEnumerable<ArticleMultimedia>>(GetAllQuery<ArticleMultimedia>()
                                    .Where(x=> articleIds.Contains(x.ArticleId.Value))
                                      .AsEnumerable());
        }
        /// <summary>
        /// Gets the article multimedia byid.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ArticleMultimedia GetArticleMultimediaByid(long Id)
        {
            var search = Query<ArticleMultimedia>.Create(x => x.Id == Id);
            return FirstOrDefaultDisposable(search);
        }
        /// <summary>
        /// Inserts the or update multimedia.
        /// </summary>
        /// <param name="articlemultimedia">The articlemultimedia.</param>
        /// <returns></returns>
        public int InsertOrUpdateMultimedia(ArticleMultimedia articlemultimedia)
        {
            return InsertOrUpdate(articlemultimedia);
        }
    }
}
