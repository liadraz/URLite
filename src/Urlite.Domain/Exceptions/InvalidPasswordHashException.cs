
namespace Urlite.Domain.Exceptions;

public class InvalidPasswordHashException : DomainException
{
    public InvalidPasswordHashException(string message)
        : base(message) { }

    public InvalidPasswordHashException(string message, Exception innerException)
        : base(message, innerException) { }

}