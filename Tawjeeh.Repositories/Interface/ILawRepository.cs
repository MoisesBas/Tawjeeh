using System;
using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface ILawRepository
    {
        int CreateLaw(Law laws);
        int DeleteLaw(Law laws);
        int UpdateLaw(Law laws);
        IList<Law> GetAllLaws();
        Law GetLawById(Int64 id);
        Law GetLawByName(string lawName);
        IEnumerable<Law> GetAll(int langId);
        Law GetLawByIdAndLangId(Int64 id, int langId);
    }
}
