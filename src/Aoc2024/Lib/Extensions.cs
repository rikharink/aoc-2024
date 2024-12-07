namespace Aoc2024.Lib;

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

    public static Grid<char> ToGrid(this string input)
    {
        var lines = input.SplitNewLines().ToArray();
        return new Grid<char>(lines.Length, lines[0].Length, input.StripNewLines().ToCharArray());
    }

    public static Grid<bool> ToGrid(this string input, Func<char, bool> predicate)
    {
        var lines = input.SplitNewLines().ToArray();
        var data = input.StripNewLines().Select(predicate).ToArray();
        return new Grid<bool>(lines.Length, lines[0].Length, data);
    }
    
    public static int Digits(this long n)
    {
        return n switch
        {
            >= 0 and < 10L => 1,
            >= 0 and < 100L => 2,
            >= 0 and < 1000L => 3,
            >= 0 and < 10000L => 4,
            >= 0 and < 100000L => 5,
            >= 0 and < 1000000L => 6,
            >= 0 and < 10000000L => 7,
            >= 0 and < 100000000L => 8,
            >= 0 and < 1000000000L => 9,
            >= 0 and < 10000000000L => 10,
            >= 0 and < 100000000000L => 11,
            >= 0 and < 1000000000000L => 12,
            >= 0 and < 10000000000000L => 13,
            >= 0 and < 100000000000000L => 14,
            >= 0 and < 1000000000000000L => 15,
            >= 0 and < 10000000000000000L => 16,
            >= 0 and < 100000000000000000L => 17,
            >= 0 and < 1000000000000000000L => 18,
            >= 0 => 19,
            > -10L => 2,
            > -100L => 3,
            > -1000L => 4,
            > -10000L => 5,
            > -100000L => 6,
            > -1000000L => 7,
            > -10000000L => 8,
            > -100000000L => 9,
            > -1000000000L => 10,
            > -10000000000L => 11,
            > -100000000000L => 12,
            > -1000000000000L => 13,
            > -10000000000000L => 14,
            > -100000000000000L => 15,
            > -1000000000000000L => 16,
            > -10000000000000000L => 17,
            > -100000000000000000L => 18,
            > -1000000000000000000L => 19,
            _ => 20
        };
    }
}