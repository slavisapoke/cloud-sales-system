using NSwag;
using Poke.CloudSalesSystem.Accounts.API.Extensions;
using Poke.CloudSalesSystem.Common.HealthCheck;
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

Log.Information("Starting Accounts API...");

builder.Services.RegisterServices(builder.Configuration);

builder.Host.UseSerilog();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerDocument(settings =>
{
    settings.Title = "Accounts Management API";
    settings.Description = "Cloud Sales System Accounts Management API";
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

builder.Services.ConfigureHealthCheckPublisher();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUI();
}

app.StartMigration();

app.UseAuthorization();

app.MapHealthChecks("/liveness", HealthCheckOptionsHelper.GetHealthCheckOptions(_ => false));
app.MapHealthChecks("/readiness", HealthCheckOptionsHelper.GetHealthCheckOptions());

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
