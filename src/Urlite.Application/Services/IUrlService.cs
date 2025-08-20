using System;
using Urlite.Application.Dtos;

namespace Urlite.Application.Services;

public interface IUrlService
{
    ShortUrlResponse? GetShortUrl(string shortCode);
    ShortUrlResponse CreateShortUrl(ShortUrlRequest request);
}
