using System;
using Urlite.Domain.Common;
using Urlite.Domain.Exceptions;

namespace Urlite.Domain.ValueObjects;

public class OriginalUrl : ValueObject
{
    public string Url { get; }

    public OriginalUrl(string url)
    {
        if (!isUrlValid(url))
        {
            throw new InvalidUrlException(url);
        }

        Url = NormalizeUrl(url);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Url;
    }

    public override string ToString() => Url;

    private bool isUrlValid(string url)
    {
        if (string.IsNullOrWhiteSpace(url) || url.Length > 2048)
        {
            return false;
        }

        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
           (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps) &&
           !string.IsNullOrEmpty(uriResult.Host);
    }

    private string NormalizeUrl(string url)
    {
        var uri = new Uri(url);
        return uri.ToString().TrimEnd('/').Trim();
    }
}
