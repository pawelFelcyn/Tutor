namespace Tutor.Shared.Exceptions;

public class AdvertisementNotFoundException : NotFoundException
{
	public AdvertisementNotFoundException(Guid id) : base($"Advertisement with id {id} was not found in database.")
	{
			
	}
}
