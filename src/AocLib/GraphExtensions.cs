namespace AocLib;

public static class GraphExtensions
{
    public delegate double HeuristicFunction<in T>(T current, T goal) where T : notnull;
    
}