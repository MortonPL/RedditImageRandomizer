using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using RedditImageRandomizer.Options;

namespace RedditImageRandomizer.Controllers;

/// <summary>
/// Controller handling the /history endpoint.
/// </summary>
[ApiController]
[Route("[controller]")]
public class HistoryController : BaseController
{
    private readonly RedditClient _redditClient;

    public HistoryController(ILogger<HistoryController> logger, IOptions<AppOptions> appOptions,
        AppDbContext appDbContext) : base(logger, appOptions, appDbContext)
    {
        _redditClient = new RedditClient(_appOptions.Subreddit);
    }

    [HttpGet]
    public IActionResult Get() =>
        Ok(_dbManager.SelectAllEntries());
}
