using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;

namespace TestProject.Shared.Logic
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("TestProject.Shared.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule<Shared.Data.AutofacModule>();
        }
    }
}
