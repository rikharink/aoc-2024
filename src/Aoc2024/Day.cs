// ReSharper disable VirtualMemberCallInConstructor
namespace Aoc2024;

public abstract class Day<TReturn>
{
    protected readonly string Input;

    protected Day(string? input = null)
    {
        Input = input ?? File.ReadAllText($"input/{GetType().Name.Replace("Day", "")}.txt");
        ParseInput();
    }

    protected virtual void ParseInput()
    {
    }
    
    public abstract TReturn Part1();
    public abstract TReturn Part2();
}