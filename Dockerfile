# syntax=docker/dockerfile:1

# Build image from prebuilt artifact
FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY build/ app/
WORKDIR /app
ENTRYPOINT ["dotnet", "RedditImageRandomizer.dll"]
