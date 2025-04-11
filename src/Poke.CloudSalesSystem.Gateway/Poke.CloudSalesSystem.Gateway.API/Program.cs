using NSwag;
using Poke.CloudSalesSystem.Common.HealthCheck;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Gateway.API.Extensions;
using Poke.CloudSalesSystem.Gateway.API.Middleware;
using Poke.CloudSalesSystem.Gateway.Application.Configuration;
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

Log.Information("Starting Gateway API...");

builder.Services.RegisterServices(builder.Configuration);

builder.Host.UseSerilog();

var servicesConfig = builder.Configuration
    .GetSection(nameof(ServicesConfiguration))
    .Get<ServicesConfiguration>();

Preconditions.CheckNotNull(servicesConfig, nameof(servicesConfig));

builder.Services.AddSingleton(servicesConfig!);
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument(settings =>
{
    settings.Title = "Cloud Sales System Gateway API";
    settings.Description = "Cloud Sales System Gateway API";
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

builder.Services.AddHealthChecks()
    .AddUrlGroup(new Uri($"{servicesConfig!.ProductServiceBaseUrl}/readiness"), 
        name: "Product API", timeout: TimeSpan.FromSeconds(3))
    .AddUrlGroup(new Uri($"{servicesConfig!.LicenceServiceBaseUrl}/readiness"), 
        name: "Licence API", timeout: TimeSpan.FromSeconds(3))
    .AddUrlGroup(new Uri($"{servicesConfig!.AccountServiceBaseUrl}/readiness"), 
        name: "Account API", timeout: TimeSpan.FromSeconds(3))
    .AddUrlGroup(new Uri($"{servicesConfig!.CustomerServiceBaseUrl}/readiness"), 
        name: "Customer API", timeout: TimeSpan.FromSeconds(3)); 

builder.Services.ConfigureHealthCheckPublisher();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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


