using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.AppDBContext
{
    public interface IAppDBContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CompressedImage> Images { get; set; }
        public DbSet<ConfigModel> Configs { get; set; }
        public DbSet<DeveloperSuggession> DeveloperSuggessions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
