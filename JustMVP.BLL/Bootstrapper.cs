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

            container.RegisterType<UserManager<User>>()
                .AsSelf();
            container.RegisterType<RoleManager<IdentityRole>>()
                .AsSelf();

            DAL.Bootstrapper.Bootstrap(container);
        }
    }
}
