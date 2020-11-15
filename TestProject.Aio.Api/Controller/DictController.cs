using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Aio.Logic;
using TestProject.Shared.Api.Controllers;
using TestProject.Shared.Data.Models;

namespace TestProject.Aio.Api.Controller
{
    [AllowAnonymous]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        [HttpPost(nameof(CreateEmployee))]
        public async Task<IActionResult> CreateEmployee(EmployeeDto model)
        {
            try
            {
                return Ok(await _employeeLogic.CreateEmployee(model));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost(nameof(DeleteEmployee))]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            try
            {
                return Ok(await _employeeLogic.DeleteEmployee(employeeId));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost(nameof(UpdateEmployee))]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto model)
        {
            try
            {
                return Ok(await _employeeLogic.UpdateEmployee(model));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet(nameof(GetEmployee))]
        public async Task<IActionResult> GetEmployee(Guid companyId)
        {
            try
            {
                return Ok(await _employeeLogic.GetEmployee(companyId));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet(nameof(GetEmployeesByCompanyId))]
        public async Task<IActionResult> GetEmployeesByCompanyId(Guid companyId)
        {
            try
            {
                return Ok(await _employeeLogic.GetEmployeesByCompanyId(companyId));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
