
using Urlite.Domain.ValueObjects;

public interface IPasswordHasher
{
    HashedPassword HashPassword(string password);
    bool VerifyPassword(string password, HashedPassword hashedPassword);
}