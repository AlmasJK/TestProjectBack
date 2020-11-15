using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Shared.Data.Models;
using TestProject.Shared.Data.Repos.Employee;

namespace TestProject.Aio.Logic
{
    public class EmployeeLogic: IEmployeeLogic
    {

        private IEmployeeRepo _employeeRepo;

        public EmployeeLogic(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<object> CreateEmployee(EmployeeDto model)
        {
            var id = await _employeeRepo.Add(new Shared.Data.Context.Employee()
            {
                BirthDate = model.BirthDate,
                CompanyId = model.CompanyId,
                Email = model.Email,
                FirstName = model.FirstName,
                IIN = model.IIN,
                SecondName = model.SecondName,
                Patronymic = model.Patronymic,
                PhoneNumber = model.PhoneNumber,
                CityId = model.CityId
            });
            await _employeeRepo.Save();
            return id;
        }

        public async Task<object> DeleteEmployee(Guid employeeId)
        {
            var employee = await _employeeRepo.GetQueryable(x => x.Id == employeeId).AsNoTracking().FirstOrDefaultAsync() ?? throw new ArgumentNullException("Компания не найден");

            await _employeeRepo.Delete(employee);
            await _employeeRepo.Save();
            return true;
        }

        public async Task<object> UpdateEmployee(EmployeeDto model)
        {
            var employee = await _employeeRepo.GetQueryable(x => x.Id == model.Id).AsNoTracking().FirstOrDefaultAsync() ?? throw new ArgumentNullException("Компания не найден");

            employee.BirthDate = model.BirthDate;
            employee.CompanyId = model.CompanyId;
            employee.Email = model.Email;
            employee.FirstName = model.FirstName;
            employee.IIN = model.IIN;
            employee.SecondName = model.SecondName;
            employee.Patronymic = model.Patronymic;
            employee.PhoneNumber = model.PhoneNumber;
            return employee;
        }

        public async Task<object> GetEmployee(Guid employeeId)
        {
            return await _employeeRepo.GetQueryable(x => x.Id == employeeId).AsNoTracking().Select(x => new EmployeeDto()
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                BirthDate = x.BirthDate,
                IIN = x.IIN,
                FirstName = x.FirstName,
                Email = x.Email,
                Patronymic = x.Patronymic,
                SecondName = x.SecondName,
                CompanyId = x.CompanyId,
                CityId = x.CityId,
                CountryId = x.City.CountryId
            }).FirstOrDefaultAsync() ?? throw new ArgumentNullException("Сотрудник не найден");
        }

        public async Task<object> GetEmployeesByCompanyId(Guid companyId)
        {
            return await _employeeRepo.GetQueryable(x => x.CompanyId == companyId).AsNoTracking().Select(x => new EmployeeDto()
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                BirthDate = x.BirthDate,
                IIN = x.IIN,
                FirstName = x.FirstName,
                Email = x.Email,
                Patronymic = x.Patronymic,
                SecondName = x.SecondName,
                CompanyId = x.CompanyId
            }).ToListAsync() ?? throw new ArgumentNullException("Сотрудник не найден");
        }
    }
}
