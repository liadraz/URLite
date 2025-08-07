
namespace Urlite.Domain.Exceptions;

public class DomainException : Exception
{
    private const string DOMAIN_ERROR = "Domain layer Error :";

    public DomainException(string message) : base(DOMAIN_ERROR + message) { }

    public DomainException(string message, Exception innerException) : base(DOMAIN_ERROR + message, innerException) { }
}

