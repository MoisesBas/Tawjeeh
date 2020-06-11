using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityModel.ReadOnly;

namespace Tawjeeh.EntityServices.Interface
{
  public interface ILawsService
    {
        int InsertOrUpdateLaw(Law laws);
        int DeleteLaw(Law laws);     
        IEnumerable<LawReadOnly> GetAll(); 
        Law GetLawById(Int64 id);
        IEnumerable<Law> GetAll(int langId);
        Law GetLawByIdAndLangId(Int64 id, int langId);
        int InsertOrUpdateLawTrans(LawTrans lawtrans);
        int DeleteLawTrans(LawTrans lawtrans);       
        Task<IEnumerable<LawTrans>> GetLawTransAll();
        LawTrans GetLawTransId(int id);
        LawTrans GetLawTransId(Int64 lawId, int langId);
    }
}
