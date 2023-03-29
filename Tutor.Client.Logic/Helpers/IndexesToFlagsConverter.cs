namespace Tutor.Client.Logic.Helpers;

internal class IndexesToFlagsConverter : IIndexesToFlagsConverter
{
    public T Convert<T>(IList<int> indexes) where T : Enum
    {
        var flagValue = 0;
        for (int i = 0; i < indexes.Count; i++)
        {
            flagValue += (int)Math.Pow(2, (indexes[i]));
        }

        return (T)(object)flagValue;
    }
}
