using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Shared.Data.Models;
using TestProject.Shared.Data.Repos.City;
using TestProject.Shared.Data.Repos.Country;
using TestProject.Shared.Data.Repos.Employee;

namespace TestProject.Aio.Logic
{
    public class DictLogic: IDictLogic
    {

        private ICountryRepo _countryRepo;
        private ICityRepo _cityRepo;

        public DictLogic(ICountryRepo countryRepo, ICityRepo cityRepo)
        {
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
        }

        public async Task<object> GetCities()
        {
            return await _cityRepo.Base().AsNoTracking().Select(x => new
            {
                x.Id,
                x.NameRu,
                x.NameKz,
                x.CountryId
            }).ToListAsync();
        }

        public async Task<object> GetCountries()
        {
            return await _countryRepo.Base().AsNoTracking().Select(x => new
            {
                x.Id,
                x.NameRu,
                x.NameKz,
            }).ToListAsync();
        }
    }
}
