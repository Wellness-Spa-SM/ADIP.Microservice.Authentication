using Authentication.Application.Services.Implementations;
using Authentication.Application.Services.Interfaces;
using Authentication.Domain.Models.Entities;
using Authentication.Infrastructure;
using Microsoft.AspNetCore.Identity;
using TM.Common.Utils.Interfaces;

namespace Authentication.Api.Extensions.Program
{
    public static class DependencyConfigExtension
    {
        public static void AddDependencyInjectionConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure();
            AddServices(builder);
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
            builder.Services.AddScoped<ISeederService, SeederService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
        }
    }
}
