using Authentication.Application.Services.Implementations;
using Authentication.Application.Services.Interfaces;
using Authentication.Infrastructure.Repositories;
using TM.Common.Utils.Interfaces;

namespace Authentication.Api.Extensions.Program
{
    public static class DependencyConfigExtension
    {
        public static void AddDependencyInjectionConfig(this WebApplicationBuilder builder)
        {
            AddRepositories(builder);
            AddServices(builder);
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISeederService, SeederService>();
        }

        private static void AddRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISeeder, AccountStatusSeederRepository>();
            builder.Services.AddScoped<ISeeder, RoleSeederRepository>();
        }
    }
}
