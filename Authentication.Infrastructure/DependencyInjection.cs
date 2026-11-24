using Authentication.Domain.Interfaces.Repositories;
using Authentication.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TM.Common.Utils.Interfaces;

namespace Authentication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            #region SEEDERS
            services.AddScoped<ISeeder, AccountStatusSeederRepository>();
            services.AddScoped<ISeeder, RoleSeederRepository>();

            #endregion

            #region REPOSITORIES
            services.AddScoped<IAccountRepository, AccountRepository>();
            #endregion

            return services;
        }
    }
}
