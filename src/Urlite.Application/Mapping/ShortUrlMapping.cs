using System;
using Urlite.Application.Dtos;
using Urlite.Domain.Entities;

namespace Urlite.Application.Mapping;

public static class ShortUrlMapping
{
    static readonly string BASE_URL = "https://urlite.com";

    public static ShortUrlResponse ToResponse(ShortUrl entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return new ShortUrlResponse
        {
            ShortCode = entity.ShortCode.Value,
            OriginalUrl = entity.OriginalUrl.Url,
            ShortUrl = $"{BASE_URL}/{entity.ShortCode.Value}",
            CreatedAt = entity.CreatedAt ?? throw new InvalidOperationException("Error: CreatedAt cannot be null")
        };
    }
}
