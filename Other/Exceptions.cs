namespace RedditImageRandomizer.Exceptions;

[Serializable]
class InvalidSubredditException : Exception
{
    public InvalidSubredditException() { }

    public InvalidSubredditException(string name)
        : base(String.Format("Invalid subreddit name: \"{0}\"", name))
    { }
}

[Serializable]
class NoImageException : Exception
{
    public NoImageException() { }

    public NoImageException(string name)
        : base(String.Format("No image found in the first page of: \"{0}\"", name))
    { }
}

[Serializable]
class MissingConfigurationException : Exception
{
    public MissingConfigurationException() { }

    public MissingConfigurationException(string name)
        : base(String.Format("Missing required configuration entry for: {0}", name))
    { }
}
