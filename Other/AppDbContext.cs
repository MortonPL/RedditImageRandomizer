using Microsoft.EntityFrameworkCore;

using RedditImageRandomizer.Models.DB;

namespace RedditImageRandomizer;

/// <summary>
/// DbContext for our database, code-first approach.
/// </summary>
public class AppDbContext : DbContext
{

    public DbSet<ImageHistoryEntry> ImageHistoryEntries => Set<ImageHistoryEntry>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ImageHistoryEntry>(entity => {
            entity.HasKey(entry => entry.Id);
            entity.Property(entry => entry.Id).ValueGeneratedOnAdd();
            entity.Property(entry => entry.Timestamp).IsRequired();
            entity.Property(entry => entry.Link).IsRequired();
        });
    }
}
