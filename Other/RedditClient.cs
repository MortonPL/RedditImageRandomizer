using Newtonsoft.Json;

using RedditImageRandomizer.Models;
using RedditImageRandomizer.Exceptions;

namespace RedditImageRandomizer;

/// <summary>
/// Helper class that sends requests to a given subreddit and handles responses.
/// </summary>
class RedditClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _subreddit;

    public RedditClient(string subreddit) =>
        _subreddit = subreddit;

    public async Task<List<string>> GetImageURLs()
    {
        var url = "https://www.reddit.com/r/" + _subreddit + "/new/.json";
        var response = await _httpClient.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        var redditObject = JsonConvert.DeserializeObject<RedditResponse>(json) ?? new RedditResponse();
        if (redditObject.Children.Count == 0) throw new InvalidSubredditException(_subreddit);

        var filtered = redditObject.Children
            .Where(x => x.PostHint == "image")
            .Select(x => x.UrlOverriddenByDest)
            .ToList();
        if (filtered.Count == 0) throw new NoImageException(_subreddit);

        return filtered;
    }

    public async Task<string> GetImageData(string url)
    {
        var response = await _httpClient.GetByteArrayAsync(url);
        return Convert.ToBase64String(response);
    }
}
