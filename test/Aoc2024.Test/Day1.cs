namespace Aoc2024.Test;

public class Day1Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             3   4
                             4   3
                             2   5
                             1   3
                             3   9
                             3   3
                             """;
        var day1 = new Day1(input);
        const string expected = "11";
        var actual = day1.Part1();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             3   4
                             4   3
                             2   5
                             1   3
                             3   9
                             3   3
                             """;
        var day1 = new Day1(input);
        const string expected = "31";
        var actual = day1.Part2();
        Assert.Equal(expected, actual);
    }
}