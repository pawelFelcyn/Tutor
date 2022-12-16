namespace Tutor.Shared.Exceptions;

public class InvalidEmailException : BadRequestException
{
    public InvalidEmailException() : base("Invalid email.")
    {
    }
}
