namespace Tutor.Shared.Exceptions;

public class CantCreateAdvertisementException : ForbiddenException
{
	public CantCreateAdvertisementException() : base("You have to be in role 'Tutor'.")
	{

	}
}
