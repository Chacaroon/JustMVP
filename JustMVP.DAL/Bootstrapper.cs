using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JustMVP.DAL
{
    public static class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder container)
        {
            var serviceCollection = new ServiceCollection()
                .AddDbContext<ApplicationContext>();

            container.Populate(serviceCollection);

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
