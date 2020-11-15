using System;
using System.Threading.Tasks;
using TestProject.Shared.Data.Models;

namespace TestProject.Aio.Logic
{
    public interface IEmployeeLogic
    {
        Task<object> CreateEmployee(EmployeeDto model);

        Task<object> DeleteEmployee(Guid employeeId);

        Task<object> UpdateEmployee(EmployeeDto model);

        Task<object> GetEmployee(Guid employeeId);

        Task<object> GetEmployeesByCompanyId(Guid companyId);
    }
}
