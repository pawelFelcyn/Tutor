namespace Tutor.Shared.Exceptions;

public class InvalidQueryException : BadRequestException
{
    public InvalidQueryException(params string[] queryParamNames)
        : base($"Invalid query params values for: {string.Join(", ", queryParamNames)}")
    {
        
    }
}
