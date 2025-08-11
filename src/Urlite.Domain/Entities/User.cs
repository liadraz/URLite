using Urlite.Domain.Common;
using Urlite.Domain.ValueObjects;

namespace Urlite.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; private set; } = null!;

    public Email EmailAddress { get; private set; } = null!;

    public HashedPassword PasswordHash { get; private set; } = null!;

    // Domain constructor
    public User(string fullName, Email emailAddress, HashedPassword passwordHash)
        : base()
    {
        SetFullName(fullName);

        EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress), "Email address cannot be null");
        PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash), "Password hash cannot be null");
    }

    // Ef Core constructor
    public User() { }

    public void UpdatePassword(HashedPassword newPasswordHash, DateTimeOffset now)
    {
        PasswordHash = newPasswordHash ?? throw new ArgumentNullException(nameof(newPasswordHash));
        SetUpdatedAt(now);
    }

    public void SetFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
        if (fullName.Length > 30) throw new ArgumentException("Full name too long (max 30).", nameof(fullName));
        FullName = fullName.Trim();
    }
}

