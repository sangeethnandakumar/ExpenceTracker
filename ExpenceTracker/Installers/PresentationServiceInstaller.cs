using Carter;
using ExpenceTracker.Installers.Base;

namespace ExpenceTracker.Installers
{
    public sealed class PresentationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IHostBuilder host, IServiceCollection services, IConfiguration configuration)
        {
            //Carter
            services.AddCarter();

            //Redis Cache
            var redisConnectionString = configuration.GetConnectionString("Redis");
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
                options.InstanceName = "TrackerCache";
            });
        }
    }
}
