using System;
using System.Collections.Generic;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;

namespace Tawjeeh.EntityServices.Interface
{
    public interface IDecisionService
    {
        #region Decision
       
        int DeleteDecision(Decision decision);
        int InsertOrUpdateDecision(Decision decision);
        IEnumerable<Decision> GetDecisionAll();
        IEnumerable<DecisionReadOnly> GetDecisionAlls();
        Decision GetDecisionById(long id);
        Decision GetDecisionLangIdAndId(long id, int langId);
        IEnumerable<DecisionReadOnly> GetDecisionByArticleId(long articleId);
        IEnumerable<DecisionReadOnly> GetDecisionByArticleIdAndLangId(long articleId, int langId);       
        #endregion

        #region Decision Trans
       
        int DeleteDecisionTrans(DecisionTrans decisionTrans);
        int InsertOrUpdateDecisionTrans(DecisionTrans decisionTrans);
        IList<DecisionTrans> GetDecisionsAllTrans();
        DecisionTrans GetdecisionTransById(int id);
        DecisionTrans GetdecisionTransLangIdAndId(long decisionId, int langId);
        DecisionTransReadOnly GetdecisionTransLangIdAndDecisionId(long decisionId, int langId);
        DecisionTrans GetdecisionTransByLangIdArticleIdAndLangId(Int64 articleId, int langId, Int64 decisionId);
        #endregion

        #region Decision Multimedia
       
        int DeleteDecisionMultimedia(DecisionMultimedia decisionmultimedia);
        int InsertOrUpdateDecisionMultimedia(DecisionMultimedia decisionmultimedia);
      
        IList<DecisionMultimedia> GetDecisionMultimediaAll();
        DecisionMultimedia GetDecisionMultimediaById(long decisionmultimediaId);
        IEnumerable<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaId(long decisionId);
        IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaIdAndLangId(long decisionId, int langId);      
        bool SetDecisionMultimediaStatus(long mediaDecisionId);
        #endregion
    }
}
