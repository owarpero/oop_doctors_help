#pragma warning disable CA1506

using DoctorsHelp.Application.Extensions;
using DoctorsHelp.Infrastructure.Persistence.Extensions;
using DoctorsHelp.Presentation.Http.Extensions;
using DoctorsHelp.Util;
using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Logging.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Testcontainers.PostgreSql;

const Profiles currentProfile = Profiles.Local;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();

if (currentProfile.Equals(Profiles.Local))
{
    var postgres = new PostgreSqlBuilder()
    .WithImage("postgres:15-alpine")
    .Build();

    await postgres.StartAsync();

    builder.Configuration["Infrastructure:Persistence:Postgres:ConnectionString"] = postgres.GetConnectionString();
}

builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();

await app.RunAsync();