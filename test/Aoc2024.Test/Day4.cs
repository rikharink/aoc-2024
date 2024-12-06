namespace Aoc2024.Test;

public class Day4Tests
{
    [Fact]
    public void PartOneFoundPointsTest()
    {
        const string input = """
                             MMMSXXMASM
                             MSAMXMSMSA
                             AMXSXMAAMM
                             MSAMASMSMX
                             XMASAMXAMM
                             XXAMMXXAMA
                             SMSMSASXSS
                             SAXAMASAAA
                             MAMMMXMMMM
                             MXMXAXMASX
                             """;
        var day = new Day4(input);

        const string expected = """
                                ....XXMAS.
                                .SAMXMS...
                                ...S..A...
                                ..A.A.MS.X
                                XMASAMX.MM
                                X.....XA.A
                                S.S.S.S.SS
                                .A.A.A.A.A
                                ..M.M.M.MM
                                .X.X.XMASX

                                """;
        day.Part1();
        var actual = day.StripNonXmas().ToString();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartTwoFoundPointsTest()
    {
        const string input = """
                             MMMSXXMASM
                             MSAMXMSMSA
                             AMXSXMAAMM
                             MSAMASMSMX
                             XMASAMXAMM
                             XXAMMXXAMA
                             SMSMSASXSS
                             SAXAMASAAA
                             MAMMMXMMMM
                             MXMXAXMASX
                             """;
        var day = new Day4(input);
        const string expected = """
                                .M.S......
                                ..A..MSMS.
                                .M.S.MAA..
                                ..A.ASMSM.
                                .M.S.M....
                                ..........
                                S.S.S.S.S.
                                .A.A.A.A..
                                M.M.M.M.M.
                                ..........

                                """;

        day.Part2();
        var actual = day.StripNonXmas().ToString();
        Assert.Equal(expected, actual);
    }


    [Fact]
    public void Part1()
    {
        const string input = """
                             MMMSXXMASM
                             MSAMXMSMSA
                             AMXSXMAAMM
                             MSAMASMSMX
                             XMASAMXAMM
                             XXAMMXXAMA
                             SMSMSASXSS
                             SAXAMASAAA
                             MAMMMXMMMM
                             MXMXAXMASX
                             """;
        var day = new Day4(input);
        const string expected = "18";
        var actual = day.Part1();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             MMMSXXMASM
                             MSAMXMSMSA
                             AMXSXMAAMM
                             MSAMASMSMX
                             XMASAMXAMM
                             XXAMMXXAMA
                             SMSMSASXSS
                             SAXAMASAAA
                             MAMMMXMMMM
                             MXMXAXMASX
                             """;
        var day = new Day4(input);
        const string expected = "9";
        var actual = day.Part2();
        Assert.Equal(expected, actual);
    }
}