using System.Reflection;
using ConsoleTables;

namespace AocLib;

public static class AdventOfCode
{
    public static int Run(params string[] args)
    {
        if (args.Length == 1)
        {
            if (args[0].Equals("all", StringComparison.CurrentCultureIgnoreCase))
            {
                AdventOfCode.RunAll();
                return 0;
            }

            if (!int.TryParse(args[0], out var day) || day < 1 || day > 25)
            {
                Console.Error.WriteLine($"Invalid day number {args[0]}");
                return 1;
            }

            AdventOfCode.Run(day);
            return 0;
        }

        AdventOfCode.Run();
        return 0;
    }

    public static void Run(string? input = null)
    {
        var dayType = Assembly.GetCallingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Day)))
            .OrderByDescending(t => int.Parse(t.Name.Replace("Day", "")))
            .First();
        Run(dayType, input);
    }

    public static void Run(int day, string? input = null)
    {
        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .First(t => t.IsSubclassOf(typeof(Day)) && t.Name == $"Day{day}");
        Run(type, input);
    }

    public static void RunAll()
    {
        var types = Assembly.GetCallingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Day)))
            .OrderBy(t => int.Parse(t.Name.Replace("Day", "")))
            .ToList();
        foreach (var type in types)
        {
            Run(type);
        }
    }

    private static void Run(Type dayType, string? input = null)
    {
        var (day, timeC, memoryC) = Measure(() => (Day)Activator.CreateInstance(dayType, input)!);
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