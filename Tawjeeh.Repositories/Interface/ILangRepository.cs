using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface ILangRepository
    {
        int CreateLang(Lang lang);
        int DeleteLang(Lang lang);
        int UpdateLang(Lang lang);
        Task<IEnumerable<Lang>> GetAll();
        Lang GetLangById(int id);
    }
}
