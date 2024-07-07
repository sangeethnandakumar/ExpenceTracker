using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.AppDBContext
{
    public interface IAppDBContext
    {
        public DbSet<Track> Tracks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
