namespace Aoc2024;

public class Day11(string? input = null) : Day(input)
{
    private Dictionary<long, long> InputStones { get; set; } = [];
    private Dictionary<long, long> WorkingStones { get; set; } = new();
    private Dictionary<long, IEnumerable<long>> Cache { get; } = new();

    private long StoneCount => WorkingStones.Values.Sum();

    protected override void ParseInput()
    {
        var stones = Input.Split(' ').Select(long.Parse).ToList();
        foreach (var stone in stones)
        {
            InputStones.SetOrProcess(stone, 1, (current, one) => current + one);
        }
    }

    private IEnumerable<long> GetNextStone(long stone)
    {
        if (Cache.TryGetValue(stone, out var value))
        {
            return value;
        }

        if (stone == 0)
        {
            Cache[0] = [1];
            return [1];
        }

        if (stone.Digits() % 2 == 0)
        {
            var divisor = NumberHelpers.LongPow(10L, (ulong)stone.Digits() / 2L);
            var left = stone / divisor;
            var right = stone % divisor;

            Cache[stone] = [left, right];
            return [left, right];
        }

        Cache[stone] = [stone * 2024L];
        return [stone * 2024L];
    }

    private void Cycle()
    {
        var newStones = new Dictionary<long, long>(WorkingStones);
        foreach (var (currentStone, count) in WorkingStones)
        {
            foreach (var nextStone in GetNextStone(currentStone))
            {
                newStones.SetOrProcess(nextStone, count, (current, addCount) => current + addCount);
            }

            newStones[currentStone] -= count;
        }

        WorkingStones = newStones;
    }

    private void Cycle(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Cycle();
        }
    }

    public override string Part1()
    {
        WorkingStones = new Dictionary<long, long>(InputStones);
        Cycle(25);
        return StoneCount.ToString();
    }

    public override string Part2()
    {
        WorkingStones = new Dictionary<long, long>(InputStones);
        Cycle(75);
        return StoneCount.ToString();
    }
}