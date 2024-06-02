namespace ExpenceTracker.Installers
{
    public interface IServiceInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
