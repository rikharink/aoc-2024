namespace Aoc2024;

public sealed class Day1(string? input = null) : Day(input)
{
    private List<int> Left { get; } = [];
    private List<int> Right { get; } = [];
    

    protected override void ParseInput()
    {
        var lines = Input.SplitNewLines();
        foreach (var line in lines)
        {
            if (line.Length == 0) continue;

            var split = line.Split("   ");
            Left.Add(int.Parse(split[0]));
            Right.Add(int.Parse(split[1]));
        }
    }

    public override string Part1()
    {
        Left.Sort();
        Right.Sort();
        var result = 0;
        for (var i = 0; i < Left.Count; i++)
        {
            var left = Left[i];
            var right = Right[i];
            var distance = Math.Abs(left - right);
            result += distance;
        }

        return result.ToString();
    }

    public override string Part2()
        => Left.Sum(number => number * Right.Count(x => x == number)).ToString();
}