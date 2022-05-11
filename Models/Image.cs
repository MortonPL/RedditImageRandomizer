namespace RedditImageRandomizer.Models;

/// <summary>
/// Model of our response with an image
/// </summary>
class Image
{
    public string Link {get; set;} = "";
    public string ImageData {get; set;} = "";

    public Image(string link, string imageData)
    {
        Link = link;
        ImageData = imageData;
    }
}
