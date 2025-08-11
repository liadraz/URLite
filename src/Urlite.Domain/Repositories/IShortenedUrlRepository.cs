using Urlite.Domain.Entities;

namespace Urlite.Domain.Repositories;

public interface IShortenedUrlRepository
{
    // Create Link
    Task AddAsync(ShortenedUrl shortenedUrl); // Save shortened URL

    // User Clicks
    Task<ShortenedUrl?> GetByShortCodeAsync(string shortCode); // redirect
    Task AddClickAsync(UrlClick urlClick); // Save click record

    // Show Dashboard
    Task<IReadOnlyList<ShortenedUrl>> GetByUserIdAsync(Guid userId); // Get all URLs for a user
    Task<int> GetClickCountAsync(Guid shortenedUrlId); // Get click count for a URL

    // Show Analytics
    Task<IReadOnlyList<UrlClick>> GetClicksAsync(Guid shortenedUrlId);
}
