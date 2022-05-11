namespace RedditImageRandomizer.Models.DB;

/// <summary>
/// Model of a history entry held in the database.
/// </summary>
public class ImageHistoryEntry
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Link { get; set; }
}
