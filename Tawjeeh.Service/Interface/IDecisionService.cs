using System;
using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
    public  interface IDecisionService
    {
        #region Decision
        int CreateDecision(Decision decision);
        int DeleteDecision(Decision decision);
        int UpdateDecision(Decision decision);
        IList<Decision> GetDecisionAll();
        Decision GetDecisionById(long id);
        Decision GetDecisionLangIdAndId(long id, int langId);
        IList<Decision> GetDecisionByArticleId(long articleId);
        IList<Decision> GetDecisionByArticleIdAndLangId(long articleId, int langId);
        Decision GetDecisionByName(string name, Int64 articleId);
        #endregion

        #region Decision Trans
        int CreateDecisionTrans(DecisionTrans decisionTrans);
        int DeleteDecisionTrans(DecisionTrans decisionTrans);
        int UpdateDecisionTrans(DecisionTrans decisionTrans);
        IList<DecisionTrans> GetDecisionsAllTrans();
        DecisionTrans GetdecisionTransById(int id);
        DecisionTrans GetdecisionTransLangIdAndId(long decisionId, int langId);
        DecisionTrans GetdecisionTransLangIdAndDecisionId(long decisionId, int langId);
        DecisionTrans GetdecisionTransByLangIdArticleIdAndLangId(Int64 articleId, int langId, Int64 decisionId);
        #endregion

        #region Decision Multimedia
        int CreateDecisionMultimedia(DecisionMultimedia decisionmultimedia);
        int DeleteDecisionMultimedia(DecisionMultimedia decisionmultimedia);
        int UpdateDecisionMultimedia(DecisionMultimedia decisionmultimedia);
        IList<DecisionMultimedia> GetDecisionMultimediaAll();
        DecisionMultimedia GetDecisionMultimediaById(long decisionmultimediaId);
        IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaId(long decisionId);
        IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaIdAndLangId(long decisionId, int langId);
        DecisionMultimedia GetDecisionMultimediaByName(string name, Int64 decisionId);
        bool SetDecisionMultimediaStatus(long mediaDecisionId);
        #endregion

    }
}
