using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityServices.Interface;
using System.Linq;
using Tawjeeh.Infrastructure;
using Tawjeeh.EntityModel.ReadOnly;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.ILawsService" />
    public class LawService : ILawsService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="LawService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public LawService(IRepositoryFactory repositoryFactory)
        {
            Guard.NotNull(repositoryFactory, nameof(repositoryFactory));
            _repositoryFactory = repositoryFactory;
        }
        /// <summary>
        /// Inserts the or update law.
        /// </summary>
        /// <param name="laws">The laws.</param>
        /// <returns></returns>
        public int InsertOrUpdateLaw(Law laws)
        {
            return _repositoryFactory.GetLawRepository.InsertOrUpdateLaw(laws);
        }
        /// <summary>
        /// Deletes the law.
        /// </summary>
        /// <param name="laws">The laws.</param>
        /// <returns></returns>
        public int DeleteLaw(Law laws)
        {
            var result = _repositoryFactory.GetLawRepository.GetLawId(laws.Id);
            return _repositoryFactory.GetLawRepository.DeleteLaw(result);
        }
        /// <summary>
        /// Deletes the law trans.
        /// </summary>
        /// <param name="lawtrans">The lawtrans.</param>
        /// <returns></returns>
        public int DeleteLawTrans(LawTrans lawtrans)
        {
            var result = _repositoryFactory.GetLawTransRepository.GetLawTransId(lawtrans.Id);
            return _repositoryFactory.GetLawTransRepository.DeleteLawTrans(result);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LawReadOnly> GetAll()
        {
            var laws = _repositoryFactory.GetLawRepository.GetAll();
            var result = (from r in laws
                          let decisioncnt = r.Articles.SelectMany(x => x.Decisions).Count()
                          let multimediaArticlecnt = r.Articles.SelectMany(x => x.MultimediaArticles).Count()
                          let decisionMultimediacnt = r.Articles.SelectMany(x => x.Decisions).SelectMany(x => x.MultimediaDecisions).Count()
                          select new LawReadOnly()
                          {
                              Id = r.Id,
                              Name = r.Name,
                              Description = r.Description,
                              IsActive = r.IsActive,
                              IsDeleted = r.IsDeleted,
                              CreatedOn = r.CreatedOn,
                              UpdatedBy = r.UpdatedBy,
                              UpdatedOn = r.UpdatedOn,
                              Articles = r.Articles,
                              DecisionCnt = decisioncnt,
                              MultimediaCnt = multimediaArticlecnt + decisionMultimediacnt
                          }).AsEnumerable();
          
            return result;
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
        /// Gets the law by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Law GetLawById(long id)
        {
            return _repositoryFactory.GetLawRepository.GetLawById(id);
        }
        /// <summary>
        /// Gets the law by identifier and language identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public Law GetLawByIdAndLangId(long id, int langId)
        {
            var result = _repositoryFactory.GetLawRepository.GetLawByIdAndLangId(id, langId);
            result.LawTranslations = result.LawTranslations.Where(x => x.LangId == langId).ToList();
            return result ?? result;
        }
        /// <summary>
        /// Gets the law trans all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<LawTrans>> GetLawTransAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the law trans identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public LawTrans GetLawTransId(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the law trans identifier.
        /// </summary>
        /// <param name="lawId">The law identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public LawTrans GetLawTransId(long lawId, int langId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Inserts the or update law trans.
        /// </summary>
        /// <param name="lawtrans">The lawtrans.</param>
        /// <returns></returns>
        public int InsertOrUpdateLawTrans(LawTrans lawtrans)
        {
            return _repositoryFactory.GetLawTransRepository.InsertOrUpdateLawTrans(lawtrans);
        }
    }
}
