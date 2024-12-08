namespace Aoc2024.Test;

public class Day7Tests
{
    [Fact]
    public void GetPermutations()
    {
        char[] allowedOperators = ['+', '*', '|'];
        const int length = 2;
        var expected = new[]
        {
            new[] { '+', '+' },
            new[] { '+', '*' },
            new[] { '+', '|' },
            new[] { '*', '+' },
            new[] { '*', '*' },
            new[] { '*', '|' },
            new[] { '|', '+' },
            new[] { '|', '*' },
            new[] { '|', '|' }
        };
        var actual = Day7.GetOperators(allowedOperators, length);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Part1()
    {
        const string input = """
                             190: 10 19
                             3267: 81 40 27
                             83: 17 5
                             156: 15 6
                             7290: 6 8 6 15
                             161011: 16 10 13
                             192: 17 8 14
                             21037: 9 7 18 13
                             292: 11 6 16 20
                             """;
        var day = new Day7(input);
        const string expected = "3749";
        var actual = day.Part1();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             190: 10 19
                             3267: 81 40 27
                             83: 17 5
                             156: 15 6
                             7290: 6 8 6 15
                             161011: 16 10 13
                             192: 17 8 14
                             21037: 9 7 18 13
                             292: 11 6 16 20
                             """;
        var day = new Day7(input);
        const string expected = "11387";
        var actual = day.Part2();
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("156: 15 6", new[] { '|' }, 156)]
    [InlineData("7290: 6 8 6 15", new[] { '*', '|', '*' }, 7290)]
    [InlineData("192: 17 8 14", new[] { '|', '+' }, 192)]
    public void CalculateTest(string equation, char[] operations, long expected)
    {
        var eq = Day7.Equation.Parse(equation);
        eq.Calculate(operations).Should().Be(expected);
    }
}