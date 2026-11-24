using Authentication.Api.Extensions.App;
using Authentication.Api.Extensions.Program;
using Authentication.Application.Services.Interfaces;
using Authentication.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlConfig();
builder.AddEndpointConfigs();
builder.AddAuthenticationConfig();
builder.AddDependencyInjectionConfig();

var app = builder.Build();

app.AddMiddlewareConfig();
app.Run();
