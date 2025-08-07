using System.Text.RegularExpressions;
using Urlite.Domain.Common;
using Urlite.Domain.Exceptions;

namespace Urlite.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; }

    public Email(string address)
    {
        if (!IsEmailValid(address))
        {
            throw new InvalidEmailException(address);
        }

        Address = address.Trim().ToLowerInvariant();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address.ToLowerInvariant();
    }

    public override string ToString()
    {
        return Address;
    }

    private static readonly Regex emailRegex = new(
            @"^[a-zA-Z0-9]([a-zA-Z0-9._-]{0,62}[a-zA-Z0-9])?@[a-zA-Z0-9]([a-zA-Z0-9.-]{0,61}[a-zA-Z0-9])?\.([a-zA-Z]{2,6})$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    private bool IsEmailValid(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || address.Length > 254)
        {
            return false;
        }

        return emailRegex.IsMatch(address);
    }
}
