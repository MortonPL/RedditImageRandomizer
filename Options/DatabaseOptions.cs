namespace RedditImageRandomizer.Options;

/// <summary>
/// Holds the app configuration values from "Database" section.
/// </summary>
public class DatabaseOptions
{
    public const string SectionName = "Database";

    public string ConnectionString {get; set;} = "";
}
