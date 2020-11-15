using System;
using System.Threading.Tasks;
using TestProject.Shared.Data.Models;

namespace TestProject.Aio.Logic
{
    public interface IDictLogic
    {
        Task<object> GetCities();
        Task<object> GetCountries();

    }
}
