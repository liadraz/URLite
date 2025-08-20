using Urlite.Domain.Common;
using Urlite.Domain.ValueObjects;

namespace Urlite.Domain.Entities;

public class ShortUrl : BaseEntity
{
    public ShortCode ShortCode { get; private set; } = null!;

    public OriginalUrl OriginalUrl { get; private set; } = null!;

    public Guid UserId { get; private set; } // Foreign key to User

    public int ClickCount { get; private set; } = 0;
    public DateTime? LastClickedAt { get; private set; }

    // Domain constructor
    public ShortUrl(ShortCode shortCode, OriginalUrl originalUrl/*, Guid userId*/) 
        : base(null, null)
    {
        ArgumentNullException.ThrowIfNull(shortCode);
        ArgumentNullException.ThrowIfNull(originalUrl);

        // if (userId == Guid.Empty)
        // throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        ShortCode = shortCode;
        OriginalUrl = originalUrl;
        // UserId = userId;
    }

    // Ef Core constructor
    public ShortUrl() { }


    public void RecordClick(DateTime now)
    {
        ClickCount++;
        LastClickedAt = now;
        SetUpdatedAt(now);
    }
}
