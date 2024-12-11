namespace AocLib;

public static class StringExtensions
{
    public static IEnumerable<string> SplitNewLines(this string input) =>
        input.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries);

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
}