namespace Tutor.Shared.Exceptions;

public class InvalidPasswordException : BadRequestException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}
