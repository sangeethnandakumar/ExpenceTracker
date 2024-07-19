using Application.AppDBContext;
using ExpenseTracker.Installers.Base;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace ExpenseTracker.Installers
{
    public sealed class PersistanceServiceInstaller : IServiceInstaller
    {
        public void InstallService(IHostBuilder host, IServiceCollection services, IConfiguration configuration)
        {
            //EF Core
            var connectionString = configuration.GetConnectionString("TrackerDB");
            var dbName = "TrackerDB";
            services.AddDbContext<AppDBContext>(options => options.UseMongoDB(connectionString, dbName));
            services.AddScoped<IAppDBContext, AppDBContext>();
        }
    }
}
