// ReSharper disable VirtualMemberCallInConstructor

namespace AocLib;

public abstract class Day
{
    private static readonly AocClient _client = new();
    protected readonly string Input;

    protected Day(string? input = null)
    {
        Input = input ?? _client.GetInput(2024, DayNumber);
        ParseInput();
    }

    public int DayNumber => int.Parse(GetType().Name.Replace("Day", ""));

    protected virtual void ParseInput()
    {
    }

    public abstract string Part1();
    public abstract string Part2();
}