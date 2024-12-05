var watch = System.Diagnostics.Stopwatch.StartNew();
var input = File.ReadAllText("input/5.txt");
var day = new Day5(input);
Console.WriteLine($"Part 1: {day.Part1()}");
Console.WriteLine($"Part 2: {day.Part2()}");
watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds}ms");