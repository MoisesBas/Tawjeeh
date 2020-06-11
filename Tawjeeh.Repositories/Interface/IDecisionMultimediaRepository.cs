using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
  public  interface IDecisionMultimediaRepository
    {
        int CreateDecisionMultimedia(DecisionMultimedia decisionmultimedia);
        int DeleteDecisionMultimedia(DecisionMultimedia decisionmultimedia);
        int UpdateDecisionMultimedia(DecisionMultimedia decisionmultimedia);
        IList<DecisionMultimedia> GetDecisionMultimediaAll();
        DecisionMultimedia GetDecisionMultimediaById(long decisionmultimediaId);   
        IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaId(long decisionId);
        IList<DecisionMultimedia> GetDecisionMultimediaByDecisionMultimediaIdAndLangId(long decisionId, int langId);
        DecisionMultimedia GetDecisionMultimediaByName(string name, Int64 decisionId);
        bool SetDecisionMultimediaStatus(long mediaDecisionId);
    }
}
