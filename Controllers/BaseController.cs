using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using RedditImageRandomizer.Options;

namespace RedditImageRandomizer.Controllers;

/// <summary>
/// Base abstract controller class that all controllers should inherit from.
/// </summary>
public abstract class BaseController: ControllerBase
{
    protected readonly ILogger<BaseController> _logger;
    protected readonly AppOptions _appOptions;
    protected readonly DbManager _dbManager;

    public BaseController(ILogger<BaseController> logger, IOptions<AppOptions> appOptions,
        AppDbContext appDbContext)
    {
        _logger = logger;
        _appOptions = appOptions.Value;
        _dbManager = new DbManager(appDbContext);
    }
}
