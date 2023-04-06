namespace Tutor.Shared.Exceptions;

public class ProfileImageExistsException : BadRequestException
{
    public ProfileImageExistsException() : base("You already have profile image published")
    {
    }
}
