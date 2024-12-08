namespace Aoc2024;

public class Day7(string? input = null) : Day(input)
{
    public List<Equation> Equations { get; private set; } = null!;

    public record Equation(long Result, List<long> Values)
    {
        public static Equation Parse(string input)
        {
            var (result, valuesString) = input.SplitOn(": ");
            return new Equation(long.Parse(result), valuesString.Split(" ").Select(long.Parse).ToList());
        }

        public long Calculate(char[] operators)
        {
            var result = Values[0];
            for (var i = 0; i < operators.Length; i++)
            {
                result = operators[i] switch
                {
                    '+' => result + Values[i + 1],
                    '*' => result * Values[i + 1],
                    '|' =>
                        result * (long)Math.Pow(10, Values[i + 1].Digits()) + Values[i + 1],
                    _ => throw new InvalidOperationException()
                };

                // early exit if the result is already too big
                if (result > Result)
                {
                    return result;
                }
            }

            return result;
        }

        public bool IsValid(char[] allowedOperators) =>
            GetOperators(allowedOperators, Values.Count - 1)
                .Any(ops => Calculate(ops) == Result);

        public override string ToString() => $"{Result}: {string.Join(" ", Values)}";
    }

    protected override void ParseInput()
    {
        Equations = Input
            .SplitNewLines()
            .Select(Equation.Parse)
            .ToList();
    }

    public static IEnumerable<char[]> GetOperators(char[] allowedOperators, int length)
    {
        if (length == 1)
        {
            return allowedOperators.Select(c => new[] { c });
        }

        return GetOperators(allowedOperators, length - 1)
            .SelectMany(p => allowedOperators, (p, c) => p.Append(c).ToArray());
    }

    public override string Part1()
        => Equations
            .Where(s => s.IsValid(['+', '*']))
            .Sum(s => s.Result).ToString();

    public override string Part2()
        => Equations
            .AsParallel()
            .Where(s => s.IsValid(['+', '*', '|']))
            .Sum(s => s.Result)
            .ToString();
}