using TestProject.Shared.Data.Context;

namespace TestProject.Shared.Data.Repos.City
{
    public class CityRepo : BaseRepo<Context.City>, ICityRepo
    {
        public CityRepo(DataContext context) : base(context)
        {
        }
    }
}
