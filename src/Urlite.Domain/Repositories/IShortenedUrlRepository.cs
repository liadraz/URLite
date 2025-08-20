using Urlite.Domain.Entities;

namespace Urlite.Domain.Repositories;

public interface IShortenedUrlRepository
{
    // Create short link
    Task AddAsync(ShortUrl shortenedUrl);

    // User Clicks
    Task<ShortUrl?> GetByShortCodeAsync(string shortCode); // for redirection
    Task AddClickAsync(UrlClick urlClick); // save click record

    // Show Dashboard
    Task<IReadOnlyList<ShortUrl>> GetByUserIdAsync(Guid userId); // Get all URLs for a user
    Task<int> GetClickCountAsync(Guid shortenedUrlId); // Get click count for a URL

    // Show Analytics
    Task<IReadOnlyList<UrlClick>> GetClicksAsync(Guid shortenedUrlId);
}
