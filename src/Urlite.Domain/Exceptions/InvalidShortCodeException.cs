using System;

namespace Urlite.Domain.Exceptions;

public class InvalidShortCodeException : DomainException
{
    public InvalidShortCodeException(string shortCode)
        : base($"The short code '{shortCode}' is not valid") { }

    public InvalidShortCodeException(string shortCode, string reason)
        : base($"The short code '{shortCode}' is not valid: {reason}") { }
}