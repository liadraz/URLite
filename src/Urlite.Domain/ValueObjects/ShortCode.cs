using System.Text.RegularExpressions;

using Urlite.Domain.Common;
using Urlite.Domain.Exceptions;

namespace Urlite.Domain.ValueObjects;

/// <summary>
/// Represents a short code for a URL
/// The short code must be exactly 6 alphanumeric characters.
/// </summary>

public class ShortCode : ValueObject
{
    public string Value { get; }

    public ShortCode(string code)
    {
        if (!IsShortCodeValid(code))
        {
            throw new InvalidShortCodeException(code);
        }

        Value = code;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    private static readonly Regex shortCodeRegex = new(
        @"^[a-zA-Z0-9]{6}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    private static bool IsShortCodeValid(string code)
    {
        return !string.IsNullOrWhiteSpace(code) && shortCodeRegex.IsMatch(code);
    }
}
