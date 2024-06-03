
using Twileloop.UOW.MongoDB.Support;

namespace ExpenceTracker.Installers
{
    public sealed class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            //MongoDB
            var connectionString = configuration.GetConnectionString("TrackerDB");
            services.AddUnitOfWork((uow) =>
            {
                uow.Connections = new List<MongoDBConnection>
                {
                    new MongoDBConnection("ExpenceTracker", connectionString)
                };
            });
        }
    }
}
