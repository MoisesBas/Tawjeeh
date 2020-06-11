using System;
using System.Collections.Generic;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.ICampaignDocumentRepository{Tawjeeh.EntityModel.CampaignDocument}" />
    public class CampaignDocumentRepository : RepositoryBase<TawjeehContext>,
               ICampaignDocumentRepository<CampaignDocument>
    {
        /// <summary>
        /// Deletes the campaign document.
        /// </summary>
        /// <param name="campDoc">The camp document.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeleteCampaignDocument(CampaignDocument campDoc)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the campaign document by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CampaignDocument GetCampaignDocumentById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the campaign documents.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<CampaignDocument> GetCampaignDocuments()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the campaign documents.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<CampaignDocument> GetCampaignDocuments(long campId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the campaign multimedia.
        /// </summary>
        /// <param name="campId">The camp identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<CampaignDocument> GetCampaignMultimedia(long campId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the or update campaign document.
        /// </summary>
        /// <param name="campDoc">The camp document.</param>
        /// <returns></returns>
        public int InsertOrUpdateCampaignDocument(CampaignDocument campDoc)
        {
            return InsertOrUpdate(campDoc);
        }

        /// <summary>
        /// Updates the campaign document.
        /// </summary>
        /// <param name="campDoc">The camp document.</param>
        /// <returns></returns>
        public int UpdateCampaignDocument(CampaignDocument campDoc)
        {
            return InsertOrUpdate(campDoc);
        }
    }
}
