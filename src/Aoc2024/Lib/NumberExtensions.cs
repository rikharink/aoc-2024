namespace Aoc2024.Lib;

public static class NumberExtensions
{
    public static int Digits(this int n)
    {
        return n switch
        {
            >= 0 and < 10 => 1,
            >= 0 and < 100 => 2,
            >= 0 and < 1000 => 3,
            >= 0 and < 10000 => 4,
            >= 0 and < 100000 => 5,
            >= 0 and < 1000000 => 6,
            >= 0 and < 10000000 => 7,
            >= 0 and < 100000000 => 8,
            >= 0 and < 1000000000 => 9,
            >= 0 => 10,
            > -10 => 2,
            > -100 => 3,
            > -1000 => 4,
            > -10000 => 5,
            > -100000 => 6,
            > -1000000 => 7,
            > -10000000 => 8,
            > -100000000 => 9,
            > -1000000000 => 10,
            _ => 11
        };
    }
    
    public static int Digits(this long n)
    {
        return n switch
        {
            >= 0 and < 10L => 1,
            >= 0 and < 100L => 2,
            >= 0 and < 1000L => 3,
            >= 0 and < 10000L => 4,
            >= 0 and < 100000L => 5,
            >= 0 and < 1000000L => 6,
            >= 0 and < 10000000L => 7,
            >= 0 and < 100000000L => 8,
            >= 0 and < 1000000000L => 9,
            >= 0 and < 10000000000L => 10,
            >= 0 and < 100000000000L => 11,
            >= 0 and < 1000000000000L => 12,
            >= 0 and < 10000000000000L => 13,
            >= 0 and < 100000000000000L => 14,
            >= 0 and < 1000000000000000L => 15,
            >= 0 and < 10000000000000000L => 16,
            >= 0 and < 100000000000000000L => 17,
            >= 0 and < 1000000000000000000L => 18,
            >= 0 => 19,
            > -10L => 2,
            > -100L => 3,
            > -1000L => 4,
            > -10000L => 5,
            > -100000L => 6,
            > -1000000L => 7,
            > -10000000L => 8,
            > -100000000L => 9,
            > -1000000000L => 10,
            > -10000000000L => 11,
            > -100000000000L => 12,
            > -1000000000000L => 13,
            > -10000000000000L => 14,
            > -100000000000000L => 15,
            > -1000000000000000L => 16,
            > -10000000000000000L => 17,
            > -100000000000000000L => 18,
            > -1000000000000000000L => 19,
            _ => 20
        };
    }
}