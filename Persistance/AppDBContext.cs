using Application.AppDBContext;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistance
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Catageory> Catageories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Employee> Employees { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Value converter for List<Platforms>
            var platformsConverter = new ValueConverter<List<Platforms>, List<int>>(
                v => v.Select(e => (int)e).ToList(),
                v => v.Select(e => (Platforms)e).ToList());

            modelBuilder.Entity<Config>().Property(e => e.PlatformsUsed).HasConversion(platformsConverter);
        }
    }
}
