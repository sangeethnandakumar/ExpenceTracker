namespace ExpenceTracker.Installers.Base
{
    public interface IServiceInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
