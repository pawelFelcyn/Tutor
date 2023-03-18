using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators.Tests.Translations;

public class TranslatorTests
{
    protected ILocalizationInfoProvider GetPlLocalizationProvider()
    {
        var polishLocalizationMock = new Mock<ILocalizationInfoProvider>();
        polishLocalizationMock.Setup(m => m.GetLocalizationInfo()).Returns("pl-PL");
        return polishLocalizationMock.Object;
    }

    protected ILocalizationInfoProvider GetEnLocalizationProvider()
    {
        var englishLocalizationMock = new Mock<ILocalizationInfoProvider>();
        englishLocalizationMock.Setup(m => m.GetLocalizationInfo()).Returns("en-US");
        return englishLocalizationMock.Object;
    }
}
