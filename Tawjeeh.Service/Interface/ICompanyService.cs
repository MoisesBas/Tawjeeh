using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Service.Interface
{
   public interface ICompanyService
    {
        int CreateCompany(Company company);
        int DeleteCompany(Company company);
        int UpdateCompany(Company company);
        IList<Company> GetCompanyAll();
        Company GetCompanyById(long id);
    }
}
