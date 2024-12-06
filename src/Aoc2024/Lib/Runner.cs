using ConsoleTables;

namespace Aoc2024.Lib;

public static class Runner
{
    public static void Run()
    {
        var dayType = typeof(Program).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Day)))
            .OrderByDescending(t => int.Parse(t.Name.Replace("Day", "")))
            .First();
        Run(dayType);
    }

    public static void Run(int day)
    {
        var type = typeof(Program).Assembly
            .GetTypes()
            .First(t => t.IsSubclassOf(typeof(Day)) && t.Name == $"Day{day}");
        Run(type);
    }

    public static void RunAll()
    {
        var types = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Day)))
            .OrderBy(t => int.Parse(t.Name.Replace("Day", "")))
            .ToList();
        foreach (var type in types)
        {
            Run(type);
        }
    }

    private static void Run(Type dayType)
    {
        var (day, timeC, memoryC) = Measure(() => (Day)Activator.CreateInstance(dayType, [null])!);

        var (part1, time1, memory1) = Measure(() => day.Part1());
        var (part2, time2, memory2) = Measure(() => day.Part2());

        Console.WriteLine($"Results for {day.GetType().Name}");
        Console.WriteLine();

        var table = new ConsoleTable("Label", "Result", "Time", "Total Memory Allocated");
        table.AddRow("Part 1", part1, $"{FormatHelpers.Time(time1)}", $"{FormatHelpers.Bytes(memory1)}");
        table.AddRow("Part 2", part2, $"{FormatHelpers.Time(time2)}", $"{FormatHelpers.Bytes(memory2)}");
        table.AddRow("Constructor", "", $"{FormatHelpers.Time(timeC)}", $"{FormatHelpers.Bytes(memoryC)}");
        table.Write(Format.MarkDown);
    }

    private static (TReturn value, TimeSpan duration, long bytes) Measure<TReturn>(Func<TReturn> f)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        var memoryBefore = GC.GetTotalAllocatedBytes(true);
        watch.Start();
        var value = f();
        watch.Stop();
        var memoryAfter = GC.GetTotalAllocatedBytes(true);
        return (value, watch.Elapsed, memoryAfter - memoryBefore);
    }
}