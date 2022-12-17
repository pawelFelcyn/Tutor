namespace Tutor.Shared.Exceptions;

public class InvalidEmailException : UnauthorizedException
{
    public InvalidEmailException() : base("Invalid email.")
    {
    }
}
