using System.Reflection;
using ConsoleTables;

namespace AocLib;

public static class AdventOfCode
{
    public static int Run(params string[] args)
    {
        var assembly = Assembly.GetCallingAssembly();
        switch (args.Length)
        {
            case 1 when args[0].Equals("all", StringComparison.CurrentCultureIgnoreCase):
                RunAll(assembly);
                return 0;
            case 1:
            {
                if (!TryGetDay(args[0], out var day))
                {
                    Console.Error.WriteLine($"Invalid day number {args[0]}");
                    return 1;
                }

                Run(assembly, day, null);
                return 0;
            }
            case 2:
            {
                if (!TryGetDay(args[0], out var day))
                {
                    Console.Error.WriteLine($"Invalid day number {args[0]}");
                    return 1;
                }
                Run(assembly, day, args[1]);
                return 0;
            }
            default:
                Run(assembly, null);
                return 0;
        }
    }
    
    private static bool TryGetDay(string arg, out int day)
    {
        if (int.TryParse(arg, out day) && day is >= 1 and <= 25)
        {
            return true;
        }
        day = 0;
        return false;
    }
    
    private static void Run(Assembly assembly, string? input)
    {
        var dayType = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Day)))
            .OrderByDescending(t => int.Parse(t.Name.Replace("Day", "")))
            .First();
        Run(dayType, input);
    }

    private static void Run(Assembly assembly, int day, string? input)
    {
        var type = assembly
            .GetTypes()
            .First(t => t.IsSubclassOf(typeof(Day)) && t.Name == $"Day{day}");
        Run(type, input);
    }

    private static void RunAll(Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Day)))
            .OrderBy(t => int.Parse(t.Name.Replace("Day", "")))
            .ToList();
        foreach (var type in types)
        {
            Run(type, null);
        }
    }

    private static void Run(Type dayType, string? input)
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