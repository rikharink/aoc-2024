namespace Aoc2024.Test;

public class Day2Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;
        var day = new Day2(input);
        const string expected = "2";
        var actual = day.Part1();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;
        var day = new Day2(input);
        const string expected = "4";
        var actual = day.Part2();
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, true)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, true)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    [InlineData(new[] { 5, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 72, 73, 75, 77, 79, 82, 79, 85 }, true)]
    [InlineData(new[] { 6, 8, 11, 12, 14, 16, 18, 16 }, true)]
    [InlineData(new[] { 12, 10, 11, 14, 17, 18, 20, 21 }, true)]
    public void Report_IsSafe_WithTolerance(int[] values, bool expected)
    {
        var report = new Day2.Report(values.ToList());
        var actual = report.IsSafe(true);
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, false)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, false)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    [InlineData(new[] { 72, 73, 75, 77, 79, 82, 79, 85 }, false)]
    [InlineData(new[] { 5, 6, 4, 2, 1 }, false)]
    [InlineData(new[] { 6, 8, 11, 12, 14, 16, 18, 16 }, false)]
    public void Report_IsSafe_WithoutTolerance(int[] values, bool expected)
    {
        var report = new Day2.Report(values.ToList());
        var actual = report.IsSafe(false);
        actual.Should().Be(expected);
    }
}