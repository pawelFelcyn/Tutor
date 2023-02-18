namespace Tutor.Client.APIAccess.Abstractions;

public class APIValidationErrorsWrapper
{
    public Dictionary<string, IEnumerable<string>>? Errors { get; set; }
}
