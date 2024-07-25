using ExpenseTracker.Converters;
using ExpenseTracker.Installers.Base;
using Serilog;
using Serilog.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Installers
{
    public sealed class ApiServiceInstaller : IServiceInstaller
    {
        public void InstallService(IHostBuilder host, IServiceCollection services, IConfiguration configuration)
        {
            var seqApiKey = configuration.GetConnectionString("Seq");

            //Serilog + Seq
            host.UseSerilog((context, services, configuration) =>
            {
                configuration
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore"))
                    .Filter.ByExcluding(Matching.FromSource("Microsoft.Hosting"))
                    .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.Mvc"))
                    .Filter.ByExcluding(Matching.FromSource("Microsoft.EntityFrameworkCore.Database.Command"))
                    .WriteTo.Console(outputTemplate: "{Timestamp:dd/MM/yy hh:mm:ss tt} [{Level:u3}] {Message}{NewLine}{Exception}")
                    .WriteTo.Async(x => x.Seq("https://seq.twileloop.com", apiKey: seqApiKey));
            });

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            //JSON
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.SerializerOptions.Converters.Add(new ISO8601DateTimeConverter());
            });
        }
    }
}
