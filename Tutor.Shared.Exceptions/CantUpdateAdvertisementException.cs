namespace Tutor.Shared.Exceptions;

public class CantUpdateAdvertisementException : ForbiddenException
{
    public CantUpdateAdvertisementException() : base("You cannot update this advertisement.")
    {
    }
}
