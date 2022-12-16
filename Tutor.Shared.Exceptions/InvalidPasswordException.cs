namespace Tutor.Shared.Exceptions;

public class InvalidPasswordException : UnauthorizedException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}
