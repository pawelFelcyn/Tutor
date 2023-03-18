namespace Tutor.Shared.Validators;

public interface ITranslator<T> where T : Enum
{
    string Translate(T message);
}