using Microsoft.EntityFrameworkCore;
using Authentication.Infrastructure.Contexts;

namespace Authentication.Api.Extensions.Program
{
    public static class SqlConfigExtension
    {
        public static void AddSqlConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AuthenticationDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("AuthenticationDbContext"),
                    x => x.MigrationsAssembly("Authentication.Infrastructure")
                );
            });
        }
    }
}
