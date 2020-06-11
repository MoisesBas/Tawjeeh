using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
  public  interface ILawRepository<T> where T: class
    {
        int InsertOrUpdateLaw(T laws);
        int DeleteLaw(T laws);          
        T GetLawById(long id);
        T GetLawByName(string lawName);
        IEnumerable<T> GetAll(int langId);
        T GetLawByIdAndLangId(Int64 id, int langId);
        IEnumerable<T> GetAll();
        T GetLawId(long id);
    }
}
