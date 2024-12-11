namespace Aoc2024.Lib;

public static class NumberHelpers
{
    public static int Gcf(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    public static int Lcm(int a, int b) 
        => a / Gcf(a, b) * b;
    
    public static int IntPow(int x, uint pow)
    {
        var ret = 1;
        while ( pow != 0 )
        {
            if ( (pow & 1) == 1 )
                ret *= x;
            x *= x;
            pow >>= 1;
        }
        return ret;
    }

    public static long LongPow(long x, ulong pow)
    {
        var ret = 1L;
        while ( pow != 0 )
        {
            if ( (pow & 1) == 1 )
                ret *= x;
            x *= x;
            pow >>= 1;
        }
        return ret;
    }
}