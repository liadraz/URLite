using System;

namespace Urlite.Domain.Exceptions;

public class UrlNotFoundException : DomainException
{
    public UrlNotFoundException(string shortCode) 
        : base($"URL with short code '{shortCode}' was not found") { }
}