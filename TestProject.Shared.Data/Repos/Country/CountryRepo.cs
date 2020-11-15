using TestProject.Shared.Data.Context;

namespace TestProject.Shared.Data.Repos.Country
{
    public class CountryRepo : BaseRepo<Context.Country>, ICountryRepo
    {
        public CountryRepo(DataContext context) : base(context)
        {
        }
    }
}
