namespace ExpenceTracker.Installers.Base
{
    public interface IServiceInstaller
    {
        void InstallService(IHostBuilder host, IServiceCollection sevices, IConfiguration configuration);
    }
}
