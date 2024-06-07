using Application.AppDBContext;
using ExpenceTracker.Installers.Base;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace ExpenceTracker.Installers
{
    public sealed class PersistanceServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TrackerDB");
            var dbName = "TrackerDB";

            services.AddDbContext<AppDBContext>(options => options.UseMongoDB(connectionString, dbName));

            services.AddScoped<IAppDBContext, AppDBContext>();
        }
    }
}
