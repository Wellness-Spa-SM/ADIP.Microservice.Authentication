using Authentication.Application.Services.Implementations;
using Authentication.Application.Services.Interfaces;
using Authentication.Domain.Interfaces.Repositories;
using Authentication.Infrastructure.Repositories;

namespace Authentication.Api.Extensions.Program
{
    public static class DependencyConfigExtension
    {
        public static void AddDependencyConfig(this WebApplicationBuilder builder)
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
            builder.Services.AddScoped<ISeederRepository, AccountStatusSeederRepository>();
        }
    }
}
