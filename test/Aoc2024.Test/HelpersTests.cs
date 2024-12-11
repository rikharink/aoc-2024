namespace Aoc2024.Test;

public class HelpersTests
{
    [Fact]
    public void Combinations()
    {
        List<int> input = [1, 2, 3];
        var actual = Helpers.Combinations(input, 2).ToList();
        var expected = new List<List<int>>
        {
            new() { 1, 2 },
            new() { 1, 3 },
            new() { 2, 3 }
        };
        actual.Should().BeEquivalentTo(expected);
    }
}