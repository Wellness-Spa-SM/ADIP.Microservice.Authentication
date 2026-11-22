using Authentication.Api.Extensions.App;
using Authentication.Api.Extensions.Program;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlConfig();
builder.AddEndpointConfigs();

var app = builder.Build();
app.AddMiddlewareConfig();
app.Run();
