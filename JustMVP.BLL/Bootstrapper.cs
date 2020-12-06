using System.Reflection;
using Autofac;
using JustMVP.Domain;
using Microsoft.AspNetCore.Identity;

namespace JustMVP.BLL
{
    public static class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder container)
        {
            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            DAL.Bootstrapper.Bootstrap(container);
        }
    }
}
