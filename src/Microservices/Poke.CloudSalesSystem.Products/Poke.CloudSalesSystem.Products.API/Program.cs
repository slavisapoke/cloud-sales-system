using NSwag;
using Poke.CloudSalesSystem.Common.Cache.Redis;
using Poke.CloudSalesSystem.Common.CloudComputingClient;
using Poke.CloudSalesSystem.Common.HealthCheck;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Products.API.Extensions;
using Poke.CloudSalesSystem.Products.Application.Configuration;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{ThreadId}] [{Level}] {Message}{NewLine}{Exception}";

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console(outputTemplate: logTemplate)
    .CreateLogger();


builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

Log.Information("Starting Products API...");

var providerConfig = builder.Configuration
    .GetSection(nameof(ProductProvidersConfiguration))
    .Get<ProductProvidersConfiguration>();

Preconditions.CheckNotNull(providerConfig, nameof(providerConfig));

builder.Services.AddSingleton(providerConfig!);

builder.Services.Configure<CloudComputingConfiguration>(
        builder.Configuration.GetSection(nameof(CloudComputingConfiguration)));

builder.Services.RegisterServices(builder.Configuration);

builder.Host.UseSerilog();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

#region SWAGGER STUFF

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerDocument(settings =>
{
    settings.Title = "Product Management API";
    settings.Description = "Cloud Sales System Product Management API";
    settings.PostProcess = document =>
    {
        document.Info.Contact = new OpenApiContact
        {
            Name = "Support",
            Email = "support@crayon.com",
            Url = "https://www.crayon.com"
        };
    };
});

#endregion

var redisConfig = Preconditions.CheckNotNull(
    builder.Configuration.GetSection(nameof(RedisConfiguration)).Get<RedisConfiguration>(),
    nameof(RedisConfiguration));

builder.Services.AddHealthChecks()
    .AddCacheHealthCheck(redisConfig);

builder.Services.ConfigureHealthCheckPublisher();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapHealthChecks("/liveness", HealthCheckOptionsHelper.GetHealthCheckOptions(_ => false));
app.MapHealthChecks("/readiness", HealthCheckOptionsHelper.GetHealthCheckOptions());

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
