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
    public class DictController : BaseController
    {
        private readonly IDictLogic _dictLogic;

        public DictController(IDictLogic dictLogic)
        {
            _dictLogic = dictLogic;
        }

        [HttpGet(nameof(GetCountries))]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                return Ok(await _dictLogic.GetCountries());
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet(nameof(GetCities))]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                return Ok(await _dictLogic.GetCities());
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
