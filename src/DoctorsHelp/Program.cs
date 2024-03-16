#pragma warning disable CA1506

using DoctorsHelp.Application.Extensions;
using DoctorsHelp.Infrastructure.Persistence.Extensions;
using DoctorsHelp.Presentation.Http.Extensions;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Logging.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var postgresContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
    .WithDatabase(new PostgreSqlTestcontainerConfiguration
    {
        Database = "postgres",
        Username = "postgres",
        Password = "postgres",
    })
    .Build();

await postgresContainer.StartAsync();

// builder.Configuration["Infrastructure:Persistence:Postgres:Host"] = postgresContainer.Hostname;
// builder.Configuration["Infrastructure:Persistence:Postgres:Port"] = postgresContainer.Port.ToString();
// builder.Configuration["Infrastructure:Persistence:Postgres:Username"] = postgresContainer.Username;
// builder.Configuration["Infrastructure:Persistence:Postgres:Password"] = postgresContainer.Password;
// builder.Configuration["Infrastructure:Persistence:Postgres:Database"] = postgresContainer.Database;
builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();

WebApplication app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();