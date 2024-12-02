namespace Aoc2024;

public class Day1 : Day<int>
{
    private List<int> Left { get; } = [];
    private List<int> Right { get; } = [];

    public Day1(string input) : base(input)
    {
        var lines = input.Split("\n");
        foreach (var line in lines)
        {
            if (line.Length == 0) continue;

            var split = line.Split("   ");
            Left.Add(int.Parse(split[0]));
            Right.Add(int.Parse(split[1]));
        }
    }

    public override int Part1()
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

        return result;
    }

    public override int Part2()
        => Left.Sum(number => number * Right.Count(x => x == number));
}