namespace Aoc2024.Test;

public class Day11Tests
{
    private const string Input = "125 17";
    
    [Fact]
    public void Part1()
    {
        var day = new Day11(Input);
        const string expected = "55312";
        var actual = day.Part1();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part2()
    {
        var day = new Day11(Input);
        const string expected = "65601038650482";
        var actual = day.Part2();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Idempotent()
    {
        var day = new Day11(Input);
        var actual1 = day.Part1();
        var actual2 = day.Part1();
        actual2.Should().Be(actual1);

        var actual3 = day.Part2();
        var actual4 = day.Part2();
        actual4.Should().Be(actual3);
    }
}