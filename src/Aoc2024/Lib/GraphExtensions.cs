namespace Aoc2024.Lib;

public static class GraphExtensions
{
    public delegate double HeuristicFunction<in T>(T current, T goal) where T : notnull;
    
}