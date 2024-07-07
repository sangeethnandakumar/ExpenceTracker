namespace Application.AppDBContext
{
    public interface IAppDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
