using System;
using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IDecisionTransRepository
    {
        int CreateDecisionTrans(DecisionTrans decisionTrans);
        int DeleteDecisionTrans(DecisionTrans decisionTrans);
        int UpdateDecisionTrans(DecisionTrans decisionTrans);
        IList<DecisionTrans> GetDecisionsAllTrans();
        DecisionTrans GetdecisionTransById(int id);
        DecisionTrans GetdecisionTransByDecisionIdAndLangId(long decisionId, int langId);
        DecisionTrans GetdecisionTransLangIdAndId(long decisionId, int langId);
        DecisionTrans GetdecisionTransLangIdAndDecisionId(long decisionId, int langId);
        DecisionTrans GetdecisionTransByLangIdArticleIdAndLangId(Int64 articleId,int langId, Int64 decisionId);
    }
}
