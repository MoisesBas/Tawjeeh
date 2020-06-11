using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;
using Tawjeeh.Infrastructure;
using log4net;

namespace Tawjeeh.Service.Service
{
    public class UtilityService : IUtilityService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UtilityService));
        private IMenuRepository _menuRepo;
        private IUserAccessRepository _menuAccessControl;
        private ILangRepository _langRepo;
        private IMultimediaTypeRepository _multimediaRepo;
        private ICountryRepository _countryRepo;
        private IUtilityRepository _utilityRepo;
        int output = 0;
        public UtilityService(IMenuRepository menuRepo, 
                              IUserAccessRepository menuAccessControl,
                              ILangRepository langRepo,
                              IMultimediaTypeRepository multimediaRepo,
                              ICountryRepository countryRepo,
                              IUtilityRepository utilityRepo)
        {
            Guard.NotNull(menuRepo,nameof(menuRepo));
            Guard.NotNull(menuAccessControl, nameof(menuAccessControl));
            Guard.NotNull(langRepo, nameof(langRepo));
            Guard.NotNull(multimediaRepo,nameof(multimediaRepo));
            Guard.NotNull(countryRepo, nameof(countryRepo));
            Guard.NotNull(utilityRepo, nameof(utilityRepo));
            _menuRepo = menuRepo;
            _menuAccessControl = menuAccessControl;
            _langRepo = langRepo;
            _multimediaRepo = multimediaRepo;
            _countryRepo = countryRepo;
            _utilityRepo = utilityRepo;
        }

        public int AddMenuAccess(MenuAccess menuaccess)
        {
            Utilities.Try(() =>
            {
               output =  _menuAccessControl.CreateUserAccess(menuaccess);

            }, "AddMenuAccess", log);

            return output;
        }

        public int CreateCountry(Country country)
        {
            return _countryRepo.CreateCountry(country);
        }

        public int CreateLang(Lang lang)
        {
            return _langRepo.CreateLang(lang);
        }
        public int CreateMenu(Menu menu)
        {
            Utilities.Try(() =>
            {
                output = _menuRepo.CreateMenu(menu);
            }, "CreateMenu", log);
            return output;
        }

        public int DeleteCountry(Country country)
        {
            return _countryRepo.DeleteCountry(country);
        }

        public int DeleteLang(Lang lang)
        {
            lang.IsActive = true;
            lang.IsDeleted = true;

            return _langRepo.UpdateLang(lang);
        }

        public int DeleteMenu(Menu menu)
        {
            Utilities.Try(() =>
            {
                output = _menuRepo.DeleteMenu(menu);
            }, "DeleteMenu", log);

            return output;
        }

        public IList<Country> GetAllCountry()
        {
            return _countryRepo.GetAllCountry();
        }

        public IList<MobileSearch> GetAllMobileSearch(int langId)
        {
            return _utilityRepo.GetAllMobileSearch(langId);
        }

        public IList<MultimediaType> GetAllMultimediaType()
        {
            return _multimediaRepo.GetAllMultimediaType();
        }

        public IList<MobileSearch> GetAllSearch()
        {
            throw new System.NotImplementedException();
        }

        public Dashboard GetDashboard(int year, int type)
        {
            return _utilityRepo.GetDashboard(year, type);
        }

        public Task<IEnumerable<Lang>> GetLangAll()
        {
            return _langRepo.GetAll();
        }

        public Lang GetLangById(int id)
        {
            return _langRepo.GetLangById(id);
        }

        public Task<IEnumerable<Menu>> GetMenuAll()
        {
            return _menuRepo.GetAll();
        }
        public Menu GetMenusById(int id)
        {
            var result = new Menu();
            Utilities.Try(() =>
            {
                result = _menuRepo.GetMenusById(id);
            }, "GetMenusById", log);

            return result;
        }

        public int UpdateCountry(Country country)
        {
            return _countryRepo.UpdateCountry(country);
        }

        public int UpdateLang(Lang lang)
        {
            return _langRepo.UpdateLang(lang);
        }

        public int UpdateMenu(Menu menu)
        {
            Utilities.Try(() =>
            {
                output = _menuRepo.UpdateMenu(menu);
            }, "UpdateMenu", log);
            return output;
        }

        public int UserAccessBatchInsert(List<MenuAccess> menuacess)
        {
            Utilities.Try(() =>
            {
                output = _menuAccessControl.CreateBatchUserAccess(menuacess);
            }, "UserAccessBatchInsert", log);
            return output;
        }

    }
}
