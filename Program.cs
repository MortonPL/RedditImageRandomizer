using Microsoft.EntityFrameworkCore;

using RedditImageRandomizer;
using RedditImageRandomizer.Exceptions;
using RedditImageRandomizer.Options;

var builder = WebApplication.CreateBuilder(args);
ReadConfig(builder, out var dbOptions);
AddServices(builder, dbOptions);

var app = builder.Build();
AddMiddleware(app);
EnsureDbConnection(app);

app.Run();

static void AddServices(WebApplicationBuilder builder, IConfigurationSection dbOptions)
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(dbOptions["ConnectionString"])
    );

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

static void AddMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
}

static void ReadConfig(WebApplicationBuilder builder, out IConfigurationSection dbOptions)
{
    var appOptions = builder.Configuration.GetSection(AppOptions.SectionName);
    dbOptions = builder.Configuration.GetSection(DatabaseOptions.SectionName);
    builder.Services.Configure<AppOptions>(appOptions);
    builder.Services.Configure<DatabaseOptions>(dbOptions);

    if (String.IsNullOrEmpty(appOptions["Subreddit"]))
        throw new MissingConfigurationException("Subreddit");
    if (String.IsNullOrEmpty(dbOptions["ConnectionString"]))
        throw new MissingConfigurationException("ConnectionString");
}

static void EnsureDbConnection(WebApplication app)
{
    using var serviceScope = app.Services.CreateScope();
    var context = serviceScope.ServiceProvider.GetService<AppDbContext>()!;
    context.Database.EnsureCreated();
    if (!context.Database.CanConnect())
        throw new Exception("Cannot connect to the database!");
}
