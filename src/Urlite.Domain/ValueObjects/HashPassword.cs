using System;
using Urlite.Domain.Common;
using Urlite.Domain.Exceptions;

namespace Urlite.Domain.ValueObjects;

public class HashedPassword : ValueObject
{
    public string Value { get; } // Stores hash string

    private HashedPassword(string hashedValue)
    {
        Value = hashedValue;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new DomainException("Password hashes should not be compared for equality.");
    }

    public override string ToString() => Value;

    public static HashedPassword FromHash(string cryptHash)
    {
        if (string.IsNullOrWhiteSpace(cryptHash))
        {
            throw new InvalidPasswordHashException("Password hash cannot be empty.");
        }

        return new HashedPassword(cryptHash);
    }
}
