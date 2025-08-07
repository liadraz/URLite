using System;

namespace Urlite.Domain.Exceptions;

public class InvalidUrlException : DomainException
{
    public InvalidUrlException(string url)
        : base($"The URL '{url}' is not valid") { }

    public InvalidUrlException(string url, string reason)
        : base($"The URL '{url}' is not valid: {reason}") { }
}


