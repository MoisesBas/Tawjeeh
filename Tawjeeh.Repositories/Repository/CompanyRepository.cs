using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateCompany(Company company)
        {
            return base.Create(company);
        }

        public int DeleteCompany(Company company)
        {
            company.UpdatedBy = 1;
            company.UpdatedOn = DateTime.Now;
            company.IsDeleted = true;
            return base.Update(company);
        }

        public IList<Company> GetCompanyAll()
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblCompany c WHERE c.IsDeleted=0";
                var result = _conn.Query<Company>(query);
                return result.ToList();
            }          
        }
        public Company GetCompanyById(long id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblCompany c WHERE c.Id=@id and c.IsDeleted=0";
                var result = _conn.Query<Company>(query, new { @Id = id });
                return result.FirstOrDefault();
            }
        }

        public int UpdateCompany(Company company)
        {
            company.UpdatedBy = 1;
            company.UpdatedOn = DateTime.Now;      
            return base.Update(company);
        }
    }
}
