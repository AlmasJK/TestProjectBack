using Autofac;
using System.Linq;
using System.Reflection;
using TestProject.Shared.Data.Repos.City;
using TestProject.Shared.Data.Repos.Company;
using TestProject.Shared.Data.Repos.Country;
using TestProject.Shared.Data.Repos.Employee;

namespace TestProject.Aio.Api
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("TestProject.Aio.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepo>().As<ICompanyRepo>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeRepo>().As<IEmployeeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CityRepo>().As<ICityRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CountryRepo>().As<ICountryRepo>().InstancePerLifetimeScope();
        }
    }
}
