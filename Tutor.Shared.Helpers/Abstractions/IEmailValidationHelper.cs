namespace Tutor.Shared.Helpers.Abstractions;

public interface IEmailValidationHelper
{
    bool IsEmailTaken(string email);
}
