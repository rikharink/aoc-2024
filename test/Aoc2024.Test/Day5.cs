namespace Aoc2024.Test;

public class Day5Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             47|53
                             97|13
                             97|61
                             97|47
                             75|29
                             61|13
                             75|53
                             29|13
                             97|29
                             53|29
                             61|53
                             97|53
                             61|29
                             47|13
                             75|47
                             97|75
                             47|61
                             75|61
                             47|29
                             75|13
                             53|13

                             75,47,61,53,29
                             97,61,53,29,13
                             75,29,13
                             75,97,47,61,53
                             61,13,29
                             97,13,75,29,47
                             """;
        var day = new Day5(input);
        const string expected = "143";
        var actual = day.Part1();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             47|53
                             97|13
                             97|61
                             97|47
                             75|29
                             61|13
                             75|53
                             29|13
                             97|29
                             53|29
                             61|53
                             97|53
                             61|29
                             47|13
                             75|47
                             97|75
                             47|61
                             75|61
                             47|29
                             75|13
                             53|13

                             75,47,61,53,29
                             97,61,53,29,13
                             75,29,13
                             75,97,47,61,53
                             61,13,29
                             97,13,75,29,47
                             """;
        var day = new Day5(input);
        const string expected = "123";
        var actual = day.Part2();
        actual.Should().Be(expected);
    }
}