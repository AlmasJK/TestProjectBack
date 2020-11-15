using TestProject.Shared.Data.Context;

namespace TestProject.Shared.Data.Repos.Employee
{
    public class EmployeeRepo : BaseRepo<Context.Employee>, IEmployeeRepo
    {
        public EmployeeRepo(DataContext context) : base(context)
        {
        }
    }
}
