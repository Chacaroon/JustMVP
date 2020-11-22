using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JustMVP.DAL
{
    public static class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder container)
        {
            container.Register(ctx =>
                {
                    var connectionString = ctx.Resolve<IConfiguration>().GetConnectionString("JustMVP");

                    var dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                        .UseSqlServer(connectionString)
                        .Options;

                    return new ApplicationContext(dbContextOptions);
                })
                .InstancePerLifetimeScope();

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
