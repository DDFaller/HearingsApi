using Microsoft.EntityFrameworkCore;
namespace HearingsApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Hearings> Hearings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Hearings>().HasKey(h => h.processNumber);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Hearings
    {
        public string? processNumber { get; set; }
        public string? date { get; set; }
        public string? court { get; set; }
        public string? correspondent { get; set; }

    }
}
