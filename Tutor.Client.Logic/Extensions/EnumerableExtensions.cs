namespace Tutor.Client.Logic.Extensions;

public static class EnumerableExtensions
{
    public static int FirstIndex<T>(this IEnumerable<T> source, Func<T, bool> condition)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (condition is null)
        {
            throw new ArgumentNullException(nameof(condition));
        }

        int count = 0;
        var enumerator = source.GetEnumerator();

        while (enumerator.MoveNext()) 
        {
            if (condition(enumerator.Current))
            {
                return count;
            }

            count++;
        }

        return -1;
    }
}
