namespace AocLib;

public static class GridExtensions
{
    public static Grid<T> ToGrid<T>(this string input, Func<char, T> parse)
    {
        var lines = input.SplitNewLines().ToArray();
        var data = input.StripNewLines().Select(parse).ToArray();
        return new Grid<T>(lines.Length, lines[0].Length, data);
    }

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
}