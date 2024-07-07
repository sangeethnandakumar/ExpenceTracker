using Application.AppDBContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public DbSet<Track> Tracks { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
