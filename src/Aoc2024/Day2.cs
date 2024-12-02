namespace Aoc2024;

public class Day2 : Day<int>
{
    public record Report(List<int> Levels)
    {
        private static bool IsCorrect(int a, int b, int expectedSign)
        {
            var sign = Math.Sign(b - a);
            var delta = Math.Abs(b - a);
            return sign == expectedSign && delta is >= 1 and <= 3;
        }

        public bool IsSafe(bool withTolerance = false)
        {
            if (Levels.Count <= 1) return true;

            var previous = Levels[0];
            var baseSign = Math.Sign(Levels[1] - Levels[0]);
            for (var i = 1; i < Levels.Count; i++)
            {
                if (IsCorrect(previous, Levels[i], baseSign))
                {
                    previous = Levels[i];
                    continue;
                }

                if (!withTolerance) return false;
                var removeCurrent = RemoveOneItem(i).IsSafe();
                var removePreviousPrevious = i > 1 && RemoveOneItem(i - 2).IsSafe();
                return removeCurrent || removePreviousPrevious;
            }

            return true;
        }

        public Report RemoveOneItem(int index) => new(Levels.RemoveOneItem(index));
    }

    private readonly List<Report> _reports;

    public List<Report> Reports => _reports;

    public Day2(string input) : base(input)
    {
        _reports = input.Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(line => new Report(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()))
            .ToList();
    }

    public override int Part1() => _reports.Count(r => r.IsSafe());
    public override int Part2() => _reports.Count(r => r.IsSafe(true));
}