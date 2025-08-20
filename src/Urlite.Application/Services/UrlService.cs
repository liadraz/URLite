using System;

using Urlite.Domain.Entities;
using Urlite.Domain.ValueObjects;

using Urlite.Application.Dtos;
using Urlite.Application.Mapping;

namespace Urlite.Application.Services;

public class UrlService : IUrlService
{
    private static readonly Dictionary<string, ShortUrl> _urls = new();

    public ShortUrlResponse? GetShortUrl(string shortCode)
    {
        var ret = _urls.TryGetValue(shortCode, out var entity);

        if (!ret || entity is null)
        {
            return null;
        }

        return ShortUrlMapping.ToResponse(entity);
    }

    public ShortUrlResponse CreateShortUrl(ShortUrlRequest request)
    {
        var shortCode = ShortCodeGenerator.Generate();

        var entity = new ShortUrl
        (
            shortCode,
            new OriginalUrl(request.OriginalUrl)
        );

        _urls[shortCode.Value] = entity;

        return ShortUrlMapping.ToResponse(entity);
    }

}
