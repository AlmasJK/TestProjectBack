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
    public class CompanyController : BaseController
    {
        private readonly ICompanyLogic _companyLogic;

        public CompanyController(ICompanyLogic companyLogic)
        {
            _companyLogic = companyLogic;
        }

        [HttpPost(nameof(CreateCompany))]
        public async Task<IActionResult> CreateCompany(CompanyDto model)
        {
            try
            {
                return Ok(await _companyLogic.CreateCompany(model));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost(nameof(DeleteCompany))]
        public async Task<IActionResult> DeleteCompany(Guid companyId)
        {
            try
            {
                return Ok(await _companyLogic.DeleteCompany(companyId));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost(nameof(UpdateCompany))]
        public async Task<IActionResult> UpdateCompany(CompanyDto model)
        {
            try
            {
                return Ok(await _companyLogic.UpdateCompany(model));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet(nameof(GetCompany))]
        public async Task<IActionResult> GetCompany(Guid companyId)
        {
            try
            {
                return Ok(await _companyLogic.GetCompany(companyId));
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet(nameof(GetCompanies))]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                return Ok(await _companyLogic.GetCompanies());
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
