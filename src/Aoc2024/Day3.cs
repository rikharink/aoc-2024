namespace Aoc2024;

public partial class Day3(string input) : Day<int>(input)
{
    [GeneratedRegex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex MulPart1();

    [GeneratedRegex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)|(do\(\)|don't\(\))", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex MulPart2();

    public override int Part1()
    {
        var result = 0;
        var matches = MulPart1().Matches(Input);

        foreach (Match match in matches)
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            result += x * y;
        }

        return result;
    }

    public override int Part2()
    {
        var result = 0;
        var matches = MulPart2().Matches(Input);
        var enabled = true;
        foreach (Match match in matches)
        {
            switch (match.Value)
            {
                case "do()":
                    enabled = true;
                    continue;
                case "don't()":
                    enabled = false;
                    continue;
            }

            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            if (enabled)
            {
                result += x * y;
            }
        }

        return result;
    }
}