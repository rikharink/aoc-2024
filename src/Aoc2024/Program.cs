var input = File.ReadAllText("input/2.txt");
var day = new Day2(input);
Console.WriteLine(day.Part1());
Console.WriteLine(day.Part2());