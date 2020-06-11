using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
    public interface ILawsService
    {
        int CreateLaw(Law laws);
        int DeleteLaw(Law laws);
        int UpdateLaw(Law laws);
        IList<Law> GetAll();
        Law GetLawById(Int64 id);
        IEnumerable<Law> GetAll(int langId);
        Law GetLawByIdAndLangId(Int64 id, int langId);
        int CreateLawTrans(LawTrans lawtrans);
        int DeleteLawTrans(LawTrans lawtrans);
        int UpdateLawTrans(LawTrans lawtrans);
        Task<IEnumerable<LawTrans>> GetLawTransAll();
        LawTrans GetLawTransId(int id);
        LawTrans GetLawTransId(Int64 lawId, int langId);
    }
}
