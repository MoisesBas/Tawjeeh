using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IDecisionTransRepository<T> where T:class
    {
        IEnumerable<T> GetdecisionTransLangIdAndDecisionId(long decisionId, int langId);
        int InsertOrUpdateDecisionTrans(T decisionTrans);
    }
}
