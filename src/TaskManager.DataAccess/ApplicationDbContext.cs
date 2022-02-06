using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Contracts;

namespace TaskManager.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskRecord> TaskRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskRecord>()
            .Property(b => b.Title)
            .HasMaxLength(250);
        modelBuilder.Entity<TaskRecord>()
            .Property(b => b.Description)
            .HasMaxLength(1000);
    }
}
