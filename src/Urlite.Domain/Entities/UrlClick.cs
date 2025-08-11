
using Urlite.Domain.Common;

namespace Urlite.Domain.Entities;

public class UrlClick : BaseEntity
{
    public Guid ShortenedUrlId { get; private set; } // Foreign key to ShortenedUrl

    public string IpAddress { get; private set; } = null!;

    public string UserAgent { get; private set; } = null!;

    public DateTime? ClickedAt { get; private set; } = null;

    // Domain constructor
    public UrlClick(Guid shortenedUrlId, string ipAddress, string? userAgent = null)
        : base()
    {
        if (shortenedUrlId == Guid.Empty)
        {
            throw new ArgumentException("ShortenedUrlId cannot be empty.", nameof(shortenedUrlId));
        }
        if (string.IsNullOrWhiteSpace(ipAddress))
        {
            throw new ArgumentException("IP address cannot be empty.", nameof(ipAddress));
        }

        ShortenedUrlId = shortenedUrlId;
        IpAddress = ipAddress;
        UserAgent = userAgent ?? string.Empty;
        ClickedAt = DateTime.UtcNow;
    }

    // Ef Core constructor
    public UrlClick() { }
}
