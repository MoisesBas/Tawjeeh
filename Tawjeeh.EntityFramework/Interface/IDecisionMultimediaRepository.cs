using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
 public  interface IDecisionMultimediaRepository<T> where T:class
    {
        IEnumerable<T> GetDecisionMultimediaByDecisionMultimediaId(long decisionId);
        T GetDecisionMultimediaById(long id);
        int InsertOrUpdateDecisionMultimedia(T decisionMultimedia);
    }
}
