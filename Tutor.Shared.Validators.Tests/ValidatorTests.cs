namespace Tutor.Shared.Validators.Tests;

public class ValidatorTests
{
    protected ITranslator<T> GetTranslator<T>() where T : Enum
    {
        var mock = new Mock<ITranslator<T>>();
        mock.Setup(m => m.Translate(It.IsAny<T>())).Returns("message");
        return mock.Object;
    }
}
