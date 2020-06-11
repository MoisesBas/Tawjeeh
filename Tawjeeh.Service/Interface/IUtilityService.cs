using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
   public interface IUtilityService
    {
       //menu
        int CreateMenu(Menu menu);
        int DeleteMenu(Menu menu);
        int UpdateMenu(Menu menu);
        Task<IEnumerable<Menu>> GetMenuAll();
        Menu GetMenusById(int id);
        int UserAccessBatchInsert(List<MenuAccess> menuacess);
        
        //Language
        int CreateLang(Lang lang);
        int DeleteLang(Lang lang);
        int UpdateLang(Lang lang);
        Task<IEnumerable<Lang>> GetLangAll();
        Lang GetLangById(int id);
        IList<MultimediaType> GetAllMultimediaType();
        IList<MobileSearch> GetAllSearch();
        IList<MobileSearch> GetAllMobileSearch(int langId);
        Dashboard GetDashboard(int year, int type);

        //country
        int CreateCountry(Country country);
        int DeleteCountry(Country country);
        int UpdateCountry(Country country);
        IList<Country> GetAllCountry();


    }
}
