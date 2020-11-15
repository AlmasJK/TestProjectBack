using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Shared.Data.Models;
using TestProject.Shared.Data.Repos.Company;

namespace TestProject.Aio.Logic
{
    public class CompanyLogic: ICompanyLogic
    {

        private ICompanyRepo _companyRepo;

        public CompanyLogic(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<object> CreateCompany(CompanyDto model)
        {
            var id = await _companyRepo.Add(new Shared.Data.Context.Company()
            {
                NameRu = model.NameRu,
                Bin = model.Bin,
                NameKz = model.NameKz
            });
            await _companyRepo.Save();
            return id;
        }

        public async Task<object> DeleteCompany(Guid companyId)
        {
            var company = await _companyRepo.GetQueryable(x => x.Id == companyId).AsNoTracking().FirstOrDefaultAsync() ?? throw new ArgumentNullException("Компания не найдена");

            await _companyRepo.Delete(company);
            await _companyRepo.Save();
            return true;
        }

        public async Task<object> UpdateCompany(CompanyDto model)
        {
            var company = await _companyRepo.GetQueryable(x => x.Id == model.Id).AsNoTracking().FirstOrDefaultAsync() ?? throw new ArgumentNullException("Компания не найдена");
            company.NameRu = model.NameRu;
            company.NameKz = model.NameKz;
            company.Bin = model.Bin;
            return company;
        }

        public async Task<object> GetCompany(Guid companyId)
        {
            return await _companyRepo.GetQueryable(x => x.Id == companyId).AsNoTracking().FirstOrDefaultAsync() ?? throw new ArgumentNullException("Компания не найдена");
        }

        public async Task<object> GetCompanies()
        {
            return await _companyRepo.Base().AsNoTracking().Select(x => new
            {
                x.NameRu,
                x.NameKz,
                x.Bin,
                x.Id
            }).ToListAsync();
        }
    }
}
