using Microsoft.Extensions.DependencyInjection;
using NSwag;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Gateway.API.Extensions;
using Poke.CloudSalesSystem.Gateway.Application.Configuration;
using Poke.CloudSalesSystem.Gateway.Application.Constants;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
