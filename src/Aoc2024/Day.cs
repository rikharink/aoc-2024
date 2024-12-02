namespace Aoc2024;

public abstract class Day<TReturn>
{
    protected readonly string Input;

    protected Day(string input)
    {
        Input = input;
    }
    
    public abstract TReturn Part1();
    public abstract TReturn Part2();
}