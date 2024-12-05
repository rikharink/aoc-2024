var watch = System.Diagnostics.Stopwatch.StartNew();
var day = new Day5();
Console.WriteLine($"Part 1: {day.Part1()}");
Console.WriteLine($"Part 2: {day.Part2()}");
watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds}ms");