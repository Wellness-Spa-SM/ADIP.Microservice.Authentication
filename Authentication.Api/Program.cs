using Authentication.Api.Extensions.App;
using Authentication.Api.Extensions.Program;
using Authentication.Application.Services.Interfaces;
using Authentication.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlConfig();
builder.AddEndpointConfigs();
builder.AddDependencyConfig();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ISeederService>();
    await seeder.RunAsync(CancellationToken.None);
}

app.AddMiddlewareConfig();
app.Run();
