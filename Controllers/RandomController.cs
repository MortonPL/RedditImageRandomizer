using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using RedditImageRandomizer.Exceptions;
using RedditImageRandomizer.Options;
using RedditImageRandomizer.Models;

namespace RedditImageRandomizer.Controllers;

/// <summary>
/// Controller handling the /random endpoint.
/// </summary>
[ApiController]
[Route("[controller]")]
public class RandomController : BaseController
{
    private readonly RedditClient _redditClient;

    public RandomController(ILogger<RandomController> logger, IOptions<AppOptions> appOptions,
        AppDbContext appDbContext) : base(logger, appOptions, appDbContext)
    {
        _redditClient = new RedditClient(_appOptions.Subreddit);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var urlList = new List<string>();
        try
        {
            urlList = await _redditClient.GetImageURLs();
        }
        catch (InvalidSubredditException e)
        {
            return StatusCode(500, e.Message);
        }
        catch (NoImageException e)
        {
            return StatusCode(500, e.Message);
        }

        var rng = new Random();
        var final = urlList[rng.Next(urlList.Count)];
        var data = await _redditClient.GetImageData(final);

        _dbManager.InsertEntry(final, DateTime.Now);

        return Ok(new Image(final, data));
    }
}
