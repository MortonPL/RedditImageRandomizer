# Introduction

A simple JSON API application made in ASP.NET (C#) & Sqlite that exposes two endpoints accepting GET requests:

* `random` - responds with a `Link` (URL) & `ImageData` (Base64) of a random image from a subreddit's "new" section. The subreddit is set in the app configuration.
* `history` - responds with a list of `Link`s and `Timestamp`s that the app has responded with.

# Configuring

Application can be configured in `appsettings.json`:

* `App` section configures the app behaviour
  * `Subreddit` (string) specifies the name, **without the r/ prefix**, of the "targeted" subreddit
* `Database` section configures the database behaviour
  * `ConnectionString` (string) sets the database connection string

All mentioned entries **must** be present, otherwise the application will raise a *MissingConfigurationException*.

# Running

## Running from executable
```bash
./RedditImageRandomizer.exe
```

## Building & running in development mode

```bash
dotnet run
```

The API will be accessible at `localhost:7279/`.

## Building & running in production mode

```bash
dotnet run --environment=Production
```

The API will be accessible at `localhost:7279/`.

## Publishing for deployment & running

```bash
dotnet publish --configuration=Release --output=build
./build/RedditImageRandomizer.exe
```

The API will be accessible at `localhost:5000/`.

## Building a Docker image & running

```bash
dotnet publish --configuration=Release --output=build
docker build -t redditimagerandomizer .
docker run -d -p 8080:80 redditimagerandomizer
```

The API will be accessible at `localhost:8080/`.
