using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.AppDBContext
{
    public interface IAppDBContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Catageory> Catageories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
