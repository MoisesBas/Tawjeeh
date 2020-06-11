using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface ILawTransRepository
    {
        int CreateLawTrans(LawTrans lawtrans);
        int DeleteLawTrans(LawTrans lawtrans);
        int UpdateLawTrans(LawTrans lawtrans);
        Task<IEnumerable<LawTrans>> GetLawTransAll();
        LawTrans GetLawTransId(int id);
        LawTrans GetLawTransId(Int64 lawId, int langId);
        LawTrans GetLawTrans(Int64 lawId, int langId);
        IList<LawTrans> GetLawTransByLawId(Int64 lawId);
    }
}
