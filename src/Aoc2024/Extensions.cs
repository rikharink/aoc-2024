namespace Aoc2024;

public static class Extensions
{
    public static List<T> RemoveOneItem<T>(this List<T> list, int index)
    {
        var listCount = list.Count;
        // Create an array to store the data.
        var result = new T[listCount - 1];
        // Copy element before the index.
        list.CopyTo(0, result, 0, index);
        // Copy element after the index.
        list.CopyTo(index + 1, result, index, listCount - 1 - index);
        return [..result];
    }

    public static string StripNewLines(this string input)
        => input.Replace("\r", "").Replace("\n", "");

    public static (string top, string bottom) SplitOnBlankLine(this string input)
    {
        var parts = input.Split(["\n\n", "\r\n\r\n"], StringSplitOptions.RemoveEmptyEntries);
        return (parts[0], parts[1]);
    }

    public static (string a, string b) SplitOn(this string input, string separator)
    {
        var parts = input.Split(separator);
        if (parts.Length != 2)
            throw new ArgumentException($"Input does not contain exactly one '{separator}' separator.");
        return (parts[0], parts[1]);
    }

    public static IEnumerable<string> SplitNewLines(this string input) =>
        input.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries);
}