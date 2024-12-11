namespace Aoc2024.Lib;

public static class CollectionExtensions
{
    public static List<T> NewListWithoutIndex<T>(this List<T> list, int index)
    {
        var listCount = list.Count;
        var result = new T[listCount - 1];
        list.CopyTo(0, result, 0, index);
        list.CopyTo(index + 1, result, index, listCount - 1 - index);
        return [..result];
    }

    public static int FindFirstRunOfSize<T>(this IList<T> list, Func<T, bool> predicate, int size) =>
        list.FindFirstRunOfSize(0, predicate, size);

    public static int FindFirstRunOfSize<T>(this IList<T> list, int start, Func<T, bool> predicate, int size)
    {
        var run = 0;
        for (var i = start; i < list.Count; i++)
        {
            if (predicate(list[i]))
            {
                run++;
                if (run == size)
                {
                    return i - size + 1;
                }
            }
            else
            {
                run = 0;
            }
        }

        return -1;
    }
}