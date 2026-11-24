using Authentication.Common.Constants;
using Authentication.Domain.Models.Entities;
using Authentication.Domain.Models.Entities.CodesTable;
using Authentication.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel;

namespace Authentication.Api.Extensions.Program
{
    public static class AuthenticationConfigExtension
    {
        public static void AddAuthenticationConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<Account, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;

                options.Password.RequiredLength = RegEx.Password.MIN_LENGTH;
                options.Password.RequiredUniqueChars = RegEx.Password.MAX_UNIQUE_CHARS;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })
            .AddEntityFrameworkStores<AuthenticationDbContext>()
            .AddDefaultTokenProviders(); ;
        }
    }
}
