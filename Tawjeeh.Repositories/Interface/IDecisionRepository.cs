using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
  public  interface IDecisionRepository
    {
        int CreateDecision(Decision decision);
        int DeleteDecision(Decision decision);
        int UpdateDecision(Decision decision);
        IList<Decision> GetDecisionAll();
        Decision GetDecisionById(long id);
        Decision GetDecisionLangIdAndId(long id, int langId);
        IList<Decision> GetDecisionByArticleId(long articleId);
        IList<Decision> GetDecisionByArticleIdAndLangId(long articleId, int langId);
        Decision GetDecisionByName(string name, Int64 articleId);
    }
}
