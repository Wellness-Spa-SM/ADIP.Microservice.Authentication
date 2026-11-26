using Authentication.Domain.Interfaces.Repositories;
using Authentication.Infrastructure.Contexts;
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
            services.AddScoped<ISeeder, AccountSeederRepository>();
            #endregion

            #region REPOSITORIES
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUnsecureAccountRepository, UnsecureAccountRepository>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            #endregion

            return services;
        }
    }
}
