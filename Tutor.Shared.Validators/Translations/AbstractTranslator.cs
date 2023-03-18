using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators;

internal abstract class AbstractTranslator<T> : ITranslator<T> where T : Enum
{
    private readonly ILocalizationInfoProvider _localizationInfoProvider;

    public AbstractTranslator(ILocalizationInfoProvider localizationInfoProvider)
    {
        _localizationInfoProvider = localizationInfoProvider;
    }

    public string Translate(T message)
    {
        var locale = _localizationInfoProvider.GetLocalizationInfo();

        if (locale == "en-US")
        {
            return TranslateToEnglish(message);
        }
        if (locale == "pl-PL")
        {
            return TranslateToPolish(message);
        }

        throw new InvalidOperationException($"Unsupported locale: {locale}.");
    }

    protected abstract string TranslateToEnglish(T message);
    protected abstract string TranslateToPolish(T message);
}
