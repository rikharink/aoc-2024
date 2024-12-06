namespace Aoc2024.Test;

public class Day3Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        var day = new Day3(input);
        const string expected = "161";
        var actual = day.Part1();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part2()
    {
        const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        var day = new Day3(input);
        const string expected = "48";
        var actual = day.Part2();
        actual.Should().Be(expected);
    }
}