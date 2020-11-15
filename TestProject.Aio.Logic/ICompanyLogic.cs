using System;
using System.Threading.Tasks;
using TestProject.Shared.Data.Models;

namespace TestProject.Aio.Logic
{
    public interface ICompanyLogic
    {
        Task<object> CreateCompany(CompanyDto model);

        Task<object> DeleteCompany(Guid companyId);

        Task<object> UpdateCompany(CompanyDto model);

        Task<object> GetCompany(Guid companyId);

        Task<object> GetCompanies();

    }
}
