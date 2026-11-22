using Scalar.AspNetCore;

namespace Authentication.Api.Extensions.App
{
    public static class MiddlewareConfigExtension
    {
        public static void AddMiddlewareConfig(this WebApplication app)
        {
            app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
