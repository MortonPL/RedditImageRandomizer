using Newtonsoft.Json;

namespace RedditImageRandomizer.Models;

/// <summary>
/// Model of a reddit response for a whole page.
/// </summary>
class RedditResponse
{
    [JsonProperty("data")]
    private RedditResponseData _data = new RedditResponseData();
    /// <summary> List of all posts provided in a page. </summary>
    [JsonIgnore]
    public List<RedditResponseChild> Children {get {return _data.Children;}}

    private class RedditResponseData
    {
        [JsonProperty("children")]
        public List<RedditResponseChild> Children {get; set;} = new List<RedditResponseChild>();
    }
}

/// <summary>
/// Model of a post in the reddit response.
/// </summary>
class RedditResponseChild
{
    [JsonProperty("data")]
    private RedditResponseChildData _data {get; set;} = new RedditResponseChildData();
    /// <summary> Post property indicating the media type. </summary>
    [JsonIgnore]
    public string PostHint {get {return _data.PostHint;}}
    /// <summary> Post property holding a URL of the media.</summary>
    [JsonIgnore]
    public string UrlOverriddenByDest {get {return _data.UrlOverriddenByDest;}}

    private class RedditResponseChildData
    {
        [JsonProperty("post_hint")]
        public string PostHint {get; set;} = "";
        [JsonProperty("url_overridden_by_dest")]
        public string UrlOverriddenByDest {get; set;} = "";
    }
}
