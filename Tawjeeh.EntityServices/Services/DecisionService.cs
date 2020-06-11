using System.Collections.Generic;
using System.Linq;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;
using Tawjeeh.EntityServices.Interface;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.IDecisionService" />
    public class DecisionService : IDecisionService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public DecisionService(IRepositoryFactory repositoryFactory)
        {
            Guard.NotNull(repositoryFactory, nameof(repositoryFactory));
            _repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Inserts the or update decision trans.
        /// </summary>
        /// <param name="decisionTrans">The decision trans.</param>
        /// <returns></returns>
        public int InsertOrUpdateDecisionTrans(DecisionTrans decisionTrans)
        {
            return _repositoryFactory.GetDecisionTransRepository.InsertOrUpdateDecisionTrans(decisionTrans);
        }
        /// <summary>
        /// Deletes the decision.
        /// </summary>
        /// <param name="decision">The decision.</param>
        /// <returns></returns>
        public int DeleteDecision(Decision decision)
        {
            var result = _repositoryFactory.GetDecisionRepository.GetDecisionById(decision.Id);
            return _repositoryFactory.GetDecisionRepository.DeleteDecision(result);
        }
        /// <summary>
        /// Deletes the decision multimedia.
        /// </summary>
        /// <param name="decisionmultimedia">The decisionmultimedia.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int DeleteDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Deletes the decision trans.
        /// </summary>
        /// <param name="decisionTrans">The decision trans.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int DeleteDecisionTrans(DecisionTrans decisionTrans)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Gets the decision all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Decision> GetDecisionAll()
        {
            return _repositoryFactory.GetDecisionRepository.GetDecisionAll();
        }
        /// <summary>
        /// Gets the decision alls.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DecisionReadOnly> GetDecisionAlls()
        {
            var result = _repositoryFactory.GetDecisionRepository.GetDecisionAlls().ToList();
            var output = (from r in result
                          let dt = r?.DecisionTranslations
                          let multimedia = r?.MultimediaDecisions
                          let article = r?.Article
                          let law = r?.Article?.Law
                          select new DecisionReadOnly()
                          {
                              Id = r.Id,
                              Name = r.Name,
                              Description = r.Description,
                              ArticleId = r.ArticleId,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                              CreatedBy = r.CreatedBy,
                              CreatedOn = r.CreatedOn,
                              Year = r.Year,
                              UpdatedBy = r.UpdatedBy,
                              UpdatedOn = r.UpdatedOn,
                              DecisionTranslations = dt,
                              MultimediaDecisions = multimedia,
                              Article = article,
                              Law = law
                          }).AsEnumerable();
            return output;
        }
        /// <summary>
        /// Gets the decision by article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public IEnumerable<DecisionReadOnly> GetDecisionByArticleId(long articleId)
        {
            var result = _repositoryFactory.GetDecisionRepository.GetDecisionByArticleIdAndLangId(articleId).ToList();
            var output = (from r in result
                          let dt = r?.DecisionTranslations
                          let multimedia = r?.MultimediaDecisions
                          let article = r?.Article
                          let law = r?.Article?.Law
                          select new DecisionReadOnly()
                          {
                              Id = r.Id,
                              Name = r.Name,
                              Description = r.Description,
                              ArticleId = r.ArticleId,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                              CreatedBy = r.CreatedBy,
                              CreatedOn = r.CreatedOn,
                              Year = r.Year,
                              UpdatedBy = r.UpdatedBy,
                              UpdatedOn = r.UpdatedOn,
                              DecisionTranslations = dt,
                              MultimediaDecisions = multimedia,
                              Article = article,
                              Law = law
                          }).AsEnumerable();
            return output;

        }
        /// <summary>
        /// Gets the decision by article identifier and language identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public IEnumerable<DecisionReadOnly> GetDecisionByArticleIdAndLangId(long articleId, int langId)

        {
            var result = _repositoryFactory.GetDecisionRepository.GetDecisionByArticleIdAndLangId(articleId).ToList();

            if (result != null)
            {
                result.ForEach(d =>
                {
                    if (d.DecisionTranslations != null)
                        d.DecisionTranslations.RemoveAll(x => x.LangId != langId);

                    if (d.Article != null)
                    {
                        if (d.Article.ArticleTranslations != null)
                        {
                            d.Article.ArticleTranslations.RemoveAll(x => x.LangId != langId);
                        }
                        if (d.Article.Law != null)
                        {
                            if (d.Article.Law.LawTranslations != null)
                            {
                                d.Article.Law.LawTranslations.RemoveAll(x => x.LangId != langId);
                            }
                        }
                    }
                });


            }
            var output = (from r in result
                          let dt = r?.DecisionTranslations
                          let multimedia = r?.MultimediaDecisions
                          let article = r?.Article
                          let law = r?.Article?.Law
                          select new DecisionReadOnly()
                          {
                              Id = r.Id,
                              Name = r.Name,
                              Description = r.Description,
                              ArticleId = r.ArticleId,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                              CreatedBy = r.CreatedBy,
                              CreatedOn = r.CreatedOn,
                              Year = r.Year,
                              UpdatedBy = r.UpdatedBy,
                              UpdatedOn = r.UpdatedOn,
                              DecisionTranslations = dt,
                              MultimediaDecisions = multimedia,
                              Article = article,
                              Law = law
                          }).AsEnumerable();
            return output;
           
        }
        /// <summary>
        /// Gets the decision by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Decision GetDecisionById(long id)
        {
            return _repositoryFactory.GetDecisionRepository.GetDecisionById(id);
        }


        /// <summary>
        /// Gets the decision language identifier and identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Decision GetDecisionLangIdAndId(long id, int langId)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Gets the decision multimedia all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<DecisionMultimedia> GetDecisionMultimediaAll()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Gets the decision multimedia by decision multimedia identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <returns></returns>
        public IEnumerable<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaId(long decisionId)
        {
            return _repositoryFactory.GetDecisionMultimediaRepository.GetDecisionMultimediaByDecisionMultimediaId(decisionId);
        }
        /// <summary>
        /// Gets the decision multimedia by decision multimedia identifier and language identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaIdAndLangId(long decisionId, int langId)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Gets the decision multimedia by identifier.
        /// </summary>
        /// <param name="decisionmultimediaId">The decisionmultimedia identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DecisionMultimedia GetDecisionMultimediaById(long decisionmultimediaId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the decisions all trans.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<DecisionTrans> GetDecisionsAllTrans()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Getdecisions the trans by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DecisionTrans GetdecisionTransById(int id)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Getdecisions the trans by language identifier article identifier and language identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <param name="decisionId">The decision identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DecisionTrans GetdecisionTransByLangIdArticleIdAndLangId(long articleId, int langId, long decisionId)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Getdecisions the trans language identifier and decision identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public DecisionTransReadOnly GetdecisionTransLangIdAndDecisionId(long decisionId, int langId)
        {
            var result = _repositoryFactory.GetDecisionTransRepository.GetdecisionTransLangIdAndDecisionId(decisionId, langId).DefaultIfEmpty();

            var output = (from dt in result
                          select new DecisionTransReadOnly
                          {
                              ArticleId = dt.ArticleId,
                              Name = dt.Name,
                              Description = dt.Description,
                              DecisionId = dt.DecisionId,
                              DecisionNo = dt.DecisionNo,
                              LangId = dt.LangId,
                              IsActive = dt.IsActive,
                              IsDeleted = dt.IsDeleted,
                              CreatedBy = dt.CreatedBy,
                              CreatedOn = dt.CreatedOn,
                              UpdatedBy = dt.UpdatedBy,
                              UpdatedOn = dt.UpdatedOn,
                              Id = dt.Id,
                              DecisionMultimedia = dt.Decision.MultimediaDecisions.DefaultIfEmpty()
                          }).FirstOrDefault();
            return output;
        }
        /// <summary>
        /// Getdecisions the trans language identifier and identifier.
        /// </summary>
        /// <param name="decisionId">The decision identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DecisionTrans GetdecisionTransLangIdAndId(long decisionId, int langId)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Inserts the or update decision.
        /// </summary>
        /// <param name="decision">The decision.</param>
        /// <returns></returns>
        public int InsertOrUpdateDecision(Decision decision)
        {
            return _repositoryFactory.GetDecisionRepository.InsertOrUpdateDecision(decision);
        }
        /// <summary>
        /// Sets the decision multimedia status.
        /// </summary>
        /// <param name="mediaDecisionId">The media decision identifier.</param>
        /// <returns></returns>
        public bool SetDecisionMultimediaStatus(long mediaDecisionId)
        {
            var result = _repositoryFactory.GetDecisionMultimediaRepository.GetDecisionMultimediaById(mediaDecisionId);
            result.IsMobile = result.IsMobile == true ? false : true;
            var output = _repositoryFactory.GetDecisionMultimediaRepository.InsertOrUpdateDecisionMultimedia(result);
            return output > 0 ? true : false;
        }

        /// <summary>
        /// Inserts the or update decision multimedia.
        /// </summary>
        /// <param name="decisionmultimedia">The decisionmultimedia.</param>
        /// <returns></returns>
        public int InsertOrUpdateDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            return _repositoryFactory.GetDecisionMultimediaRepository.InsertOrUpdateDecisionMultimedia(decisionmultimedia);
        }
    }
}
