using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Shared.Data.Context;

namespace TestProject.Shared.Data.Repos.Company
{
    public class CompanyRepo : BaseRepo<Context.Company>, ICompanyRepo
    {
        public CompanyRepo(DataContext context) : base(context)
        {
        }
    }
}
