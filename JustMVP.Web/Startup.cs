using Autofac;
using JustMVP.DAL;
using JustMVP.Domain;
using JustMVP.Domain.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using JustMVP.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;

namespace JustMVP.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            BLL.Bootstrapper.Bootstrap(builder);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddSwaggerGen();

            var jwtOptionsConfiguration = Configuration.GetSection("JwtOptions");
            var jwtOptions = jwtOptionsConfiguration.Get<JwtOptions>();

            services.Configure<JwtOptions>(jwtOptionsConfiguration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwtOptions.Audience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jwtOptions.IssuerSigningKey
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (httpContext, next) =>
            {
                try
                {
                    await next();
                }
                catch
                {
                    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new ResponseData(ErrorTypeEnum.Unknown)));
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
