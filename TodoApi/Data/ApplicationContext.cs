using Microsoft.EntityFrameworkCore;

namespace TaskTrackerApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Models.Task> Tasks { get; set; } = default!;
    }
}
