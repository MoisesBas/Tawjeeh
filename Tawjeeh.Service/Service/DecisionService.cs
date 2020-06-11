using log4net;
using System;
using System.Collections.Generic;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class DecisionService : IDecisionService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DecisionService));
        private IDecisionRepository _decisionRepository;
        private IDecisionTransRepository _decisionTransRepository;
        private IDecisionMultimediaRepository _decisionMultimediaRepository;
        public DecisionService(IDecisionRepository decisionRepository, 
                               IDecisionTransRepository decisionTransRepository,
                               IDecisionMultimediaRepository decisionMultimediaRepository)
        {
            Guard.NotNull(decisionRepository, nameof(decisionRepository));
            Guard.NotNull(decisionTransRepository, nameof(decisionTransRepository));
            Guard.NotNull(decisionMultimediaRepository, nameof(decisionMultimediaRepository));
            _decisionRepository = decisionRepository;
            _decisionTransRepository = decisionTransRepository;
            _decisionMultimediaRepository = decisionMultimediaRepository;
        }
        #region Decision
        public int CreateDecision(Decision decision)
        {
            var isExists = this.GetDecisionByName(decision.Name, Convert.ToInt64(decision.ArticleId));
            if (isExists != null)
                throw new Exception(decision.Name + "decision is already exist in article.,");

            decision.IsActive = true;
            decision.IsDeleted = false;
            decision.CreatedOn = DateTime.Now;
            return _decisionRepository.CreateDecision(decision);
        }
        public int UpdateDecision(Decision decision)
        {
            decision.UpdatedOn = DateTime.Now;
            return _decisionRepository.UpdateDecision(decision);
        }
        public int DeleteDecision(Decision decision)
        {
            decision.IsActive = true;
            decision.IsDeleted = true;
            decision.UpdatedOn = DateTime.Now;
            return _decisionRepository.UpdateDecision(decision);
        }
        public IList<Decision> GetDecisionAll()
        {
            return _decisionRepository.GetDecisionAll();
        }

        public IList<Decision> GetDecisionByArticleId(long articleId)
        {
            return _decisionRepository.GetDecisionByArticleId(articleId);
        }

        public IList<Decision> GetDecisionByArticleIdAndLangId(long articleId, int langId)
        {
            return _decisionRepository.GetDecisionByArticleIdAndLangId(articleId, langId);
        }

        public Decision GetDecisionById(long id)
        {
            return _decisionRepository.GetDecisionById(id);
        }

        public Decision GetDecisionByName(string name, long articleId)
        {
            return _decisionRepository.GetDecisionByName(name, articleId);
        }

        public Decision GetDecisionLangIdAndId(long id, int langId)
        {
            return _decisionRepository.GetDecisionLangIdAndId(id, langId);
        }
        #endregion

        #region Decision Translation
        public IList<DecisionTrans> GetDecisionsAllTrans()
        {
            return _decisionTransRepository.GetDecisionsAllTrans();
        }

        public DecisionTrans GetdecisionTransById(int id)
        {
            return _decisionTransRepository.GetdecisionTransById(id);
        }

        public DecisionTrans GetdecisionTransByLangIdArticleIdAndLangId(long articleId, int langId, long decisionId)
        {
            return _decisionTransRepository.GetdecisionTransByLangIdArticleIdAndLangId(articleId, langId, decisionId);
        }

        public DecisionTrans GetdecisionTransLangIdAndId(long decisionId, int langId)
        {
            return _decisionTransRepository.GetdecisionTransLangIdAndId(decisionId, langId);
        }

        public DecisionTrans GetdecisionTransLangIdAndDecisionId(long decisionId, int langId)
        {
            return _decisionTransRepository.GetdecisionTransLangIdAndDecisionId(decisionId, langId);
        }
        public int CreateDecisionTrans(DecisionTrans decisionTrans)
        {
            decisionTrans.IsActive = true;
            decisionTrans.IsDeleted = false;
            decisionTrans.CreatedOn = DateTime.Now;
            var isexists = _decisionTransRepository.GetdecisionTransByDecisionIdAndLangId(Convert.ToInt64(decisionTrans.DecisionId),
                Convert.ToInt32(decisionTrans.LangId));
            if (isexists != null)
                throw new Exception("Decision translation is already Exists.,");
            var decisions = _decisionRepository.GetDecisionById(Convert.ToInt64(decisionTrans.DecisionId));
            Guard.NotNull(decisions, "Decision is not exists");
            decisionTrans.DecisionNo = decisions.DecisionNo;
            return _decisionTransRepository.CreateDecisionTrans(decisionTrans);
        }              

        public int DeleteDecisionTrans(DecisionTrans decisionTrans)
        {
            decisionTrans.IsActive = true;
            decisionTrans.IsDeleted = true;
            decisionTrans.UpdatedOn = DateTime.Now;
            return _decisionTransRepository.UpdateDecisionTrans(decisionTrans);
        }

        public int UpdateDecisionTrans(DecisionTrans decisionTrans)
        {
            decisionTrans.IsActive = true;
            decisionTrans.IsDeleted = false;
            decisionTrans.UpdatedOn = DateTime.Now;
            return _decisionTransRepository.UpdateDecisionTrans(decisionTrans);
        }
        #endregion

        #region Decision Multimedia
        public int CreateDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            var isexists = _decisionMultimediaRepository.GetDecisionMultimediaByName(decisionmultimedia.FileName, 
                Convert.ToInt64(decisionmultimedia.DecisionId));

            if (isexists != null) throw new Exception("File Name is already exists.,");

            decisionmultimedia.CreatedOn = DateTime.Now;
            decisionmultimedia.IsActive = true;
            decisionmultimedia.IsDeleted = false;

            return _decisionMultimediaRepository.CreateDecisionMultimedia(decisionmultimedia);
        }         
        public int DeleteDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            decisionmultimedia.UpdatedOn = DateTime.Now;     
            decisionmultimedia.IsDeleted = true;
            return _decisionMultimediaRepository.UpdateDecisionMultimedia(decisionmultimedia);
        }
        public int UpdateDecisionMultimedia(DecisionMultimedia decisionmultimedia)
        {
            decisionmultimedia.UpdatedOn = DateTime.Now;        
            return _decisionMultimediaRepository.UpdateDecisionMultimedia(decisionmultimedia);
        }
        public IList<DecisionMultimedia> GetDecisionMultimediaAll()
        {
            return _decisionMultimediaRepository.GetDecisionMultimediaAll();
        }
        public DecisionMultimedia GetDecisionMultimediaById(long decisionmultimediaId)
        {
            return _decisionMultimediaRepository.GetDecisionMultimediaById(decisionmultimediaId);
        }
        public IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaId(long decisionId)
        {
            return _decisionMultimediaRepository.GetDecisionMultimediaByDecisionMultimediaId(decisionId);
        }

        public IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaIdAndLangId(long decisionId, int langId)
        {
            return _decisionMultimediaRepository.GetDecisionMultimediaByDecisionMultimediaIdAndLangId(decisionId, langId);
        }
        public DecisionMultimedia GetDecisionMultimediaByName(string name, long decisionId)
        {
            return _decisionMultimediaRepository.GetDecisionMultimediaByName(name, decisionId);
        }
        public bool SetDecisionMultimediaStatus(long mediaDecisionId)
        {
            return _decisionMultimediaRepository.SetDecisionMultimediaStatus(mediaDecisionId);
        }
        #endregion

    }

}
