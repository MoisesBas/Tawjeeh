using System.Collections.Generic;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class CompanyService:ICompanyService
    {
        private ICompanyRepository _companyRepo;
        public CompanyService(ICompanyRepository companyRepo)
        {
            Guard.NotNull(companyRepo, nameof(companyRepo));
            _companyRepo = companyRepo;
         
        }
        public int CreateCompany(Company company) => _companyRepo.CreateCompany(company);
        public int DeleteCompany(Company company) => _companyRepo.DeleteCompany(company);
        public IList<Company> GetCompanyAll() => _companyRepo.GetCompanyAll();
        public Company GetCompanyById(long id) => _companyRepo.GetCompanyById(id);
        public int UpdateCompany(Company company) => _companyRepo.UpdateCompany(company);
        
    }
}
