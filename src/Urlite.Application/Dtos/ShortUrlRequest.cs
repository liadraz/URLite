using System;

namespace Urlite.Application.Dtos;

public sealed record ShortUrlRequest
{
    public string OriginalUrl { get; init; } = string.Empty;
    // public Guid UserId { get; init; }
}
