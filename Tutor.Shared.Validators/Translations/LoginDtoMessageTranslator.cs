using System.Diagnostics;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators.Translations;

internal class LoginDtoMessageTranslator : AbstractTranslator<LoginDtoValidationMessage>
{
    public LoginDtoMessageTranslator(ILocalizationInfoProvider localizationInfoProvider) 
        : base(localizationInfoProvider)
    {
    }

    protected override string TranslateToEnglish(LoginDtoValidationMessage message) => message switch
    {
        LoginDtoValidationMessage.EmailMustNotBeEmpty => "Email must not be empty.",
        LoginDtoValidationMessage.PasswordMustNotBeEmpty => "Password must not be empty.",
        _ => throw new UnreachableException()
    };
    

    protected override string TranslateToPolish(LoginDtoValidationMessage message) => message switch
    {
        LoginDtoValidationMessage.EmailMustNotBeEmpty => "Email nie może być pusty.",
        LoginDtoValidationMessage.PasswordMustNotBeEmpty => "Hasło nie może być puste.",
        _ => throw new UnreachableException()
    };
}
