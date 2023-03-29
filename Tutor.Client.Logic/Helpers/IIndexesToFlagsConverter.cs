namespace Tutor.Client.Logic.Helpers;

public interface IIndexesToFlagsConverter
{
    T Convert<T>(IList<int> indexes) where T : Enum;
}
