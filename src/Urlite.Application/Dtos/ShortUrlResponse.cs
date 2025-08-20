
namespace Urlite.Application.Dtos;

public sealed record ShortUrlResponse
{
    public string ShortCode { get; init; } = string.Empty;
    public string OriginalUrl { get; init; } = string.Empty;
    public string ShortUrl { get; init; } = string.Empty;
    public DateTimeOffset CreatedAt { get; init; }
}
