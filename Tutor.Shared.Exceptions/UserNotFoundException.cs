namespace Tutor.Shared.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid id) 
        : base($"User with id {id} was not found in database.")
    {
    }
}
