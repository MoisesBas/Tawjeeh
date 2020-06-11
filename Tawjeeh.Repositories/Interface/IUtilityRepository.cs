using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IUtilityRepository
    {
        IList<MobileSearch> GetAllMobileSearch();
        IList<MobileSearch> GetAllMobileSearch(int langId);
        Dashboard GetDashboard(int year, int type);
    }
}
