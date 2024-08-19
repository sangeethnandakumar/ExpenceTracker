using Carter;
using ExpenseTracker.Installers.Base;
using Presentation.MappingProfiles;

namespace ExpenseTracker.Installers
{
    public sealed class PresentationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IHostBuilder host, IServiceCollection services, IConfiguration configuration)
        {
            //Automapper
            services.AddAutoMapper(typeof(PresentationMappingProfile));

            //Redis Cache
            var redisConnectionString = configuration.GetConnectionString("Redis");
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
                options.InstanceName = "TrackerCache";
            });

            //Carter
            services.AddCarter();
        }
    }
}
