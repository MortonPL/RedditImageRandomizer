namespace RedditImageRandomizer.Options;

/// <summary>
/// Holds the app configuration values from "App" section.
/// </summary>
public class AppOptions
{
    public const string SectionName = "App";

    public string Subreddit {get; set;} = "";
}
