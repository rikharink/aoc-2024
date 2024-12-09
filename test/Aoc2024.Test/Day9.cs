namespace Aoc2024.Test;

public class Day9Tests
{
    [Fact]
    public void DefragTest()
    {
        const string input = "12345";
        var day = new Day9(input);
        var defraggedDisk = day.Defragment();
        var actual = Day9.DiskString(defraggedDisk);
        const string expectedDiskString = "022111222......";
        actual.Should().Be(expectedDiskString);
    }

    [Fact]
    public void FindFirstFreeSpaceOfSizeTest()
    {
        const string input = "2334133121414131402";
        const int expected1 = 8;
        var day = new Day9(input);
        var str = Day9.DiskString(day.Disk);
        var actual1 = Day9.FindFirstFreeSpace(day.Disk,  4);
        actual1.Should().Be(expected1);
    }

    [Fact]
    public void DefragSmartTest()
    {
        const string input = "2333133121414131402";
        const string expected = "00992111777.44.333....5555.6666.....8888..";
        var day = new Day9(input);
        var defraggedDisk = day.DefragmentSmart();
        var actual = Day9.DiskString(defraggedDisk);
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part1()
    {
        const string input = """
                             2333133121414131402
                             """;
        var day = new Day9(input);
        const string expected = "1928";
        var actual = day.Part1();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             2333133121414131402
                             """;
        var day = new Day9(input);
        const string expected = "2858";
        var actual = day.Part2();
        actual.Should().Be(expected);
    }
}