using Application.AppDBContext;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDBContext : DbContext, IAppDBContext
    {


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
