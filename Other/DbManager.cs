using RedditImageRandomizer.Models.DB;

namespace RedditImageRandomizer;

/// <summary>
/// Database accessor class providing methods for database queries.
/// </summary>
public class DbManager
{
    private readonly AppDbContext _dbContext;

    public DbManager(AppDbContext appDbContext) =>
        _dbContext = appDbContext;

    public List<ImageHistoryEntry> SelectAllEntries() =>
        _dbContext.ImageHistoryEntries.ToList();

    public void InsertEntry(string link, DateTime timestamp)
    {
        var entry = new ImageHistoryEntry{Timestamp=timestamp, Link=link};
        _dbContext.Add(entry);
        _dbContext.SaveChanges();
    }
}
