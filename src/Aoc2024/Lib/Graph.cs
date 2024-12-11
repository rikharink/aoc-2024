namespace Aoc2024.Lib;

public class Graph<T> where T : notnull
{
    private Dictionary<T, Dictionary<T, double>> AdjacencyList { get; } = new();

    public void AddVertex(T vertex)
    {
        if (!AdjacencyList.ContainsKey(vertex))
        {
            AdjacencyList[vertex] = new Dictionary<T, double>();
        }
    }

    public void AddEdge(T from, T to, double weight = 0, bool bidirectional = false)
    {
        AddVertex(from);
        AddVertex(to);
        AdjacencyList[from][to] = weight;
        if (bidirectional)
        {
            AdjacencyList[to][from] = weight;
        }
    }

    public IEnumerable<T> FindVertices(Func<T, bool> predicate)
        => AdjacencyList.Keys.Where(predicate);

    public IEnumerable<(T Vertex, double Weight)> GetNeighbors(T vertex)
        => AdjacencyList.TryGetValue(vertex, out var neighbors)
            ? neighbors.Select(kvp => (kvp.Key, kvp.Value))
            : Enumerable.Empty<(T, double)>();
}