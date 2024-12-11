namespace Aoc2024.Test;

public class Day10Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             89010123
                             78121874
                             87430965
                             96549874
                             45678903
                             32019012
                             01329801
                             10456732
                             """;
        var day = new Day10(input);
        const string expected = "36";
        var actual = day.Part1();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             89010123
                             78121874
                             87430965
                             96549874
                             45678903
                             32019012
                             01329801
                             10456732
                             """;
        var day = new Day10(input);
        const string expected = "81";
        var actual = day.Part2();
        actual.Should().Be(expected);
    }
}