namespace Aoc2024;

public class Day10(string? input = null) : Day(input)
{
    private readonly record struct HikePoint(short Value, Point Location);

    private Graph<HikePoint> Graph { get; set; } = null!;
    private IList<ICollection<HikePoint>> _trails = null!;
    private IList<HikePoint> _trailheads = null!;

    protected override void ParseInput()
    {
        var map = Input.ToGrid(c => short.Parse(c.ToString()));
        Graph = new Graph<HikePoint>();
        for (var y = 0; y < map.Height; y++)
        {
            for (var x = 0; x < map.Width; x++)
            {
                var value = map[x, y];
                var neighbors = map.GetNeighbourLocations((x, y)).Where(n => map[n] == value + 1);
                foreach (var neighbor in neighbors)
                {
                    Graph.AddEdge(new HikePoint(value, (x, y)), new HikePoint((short)(value + 1), neighbor));
                }
            }
        }

        _trails = FindTrails().ToList();
        _trailheads = Trailheads(_trails);
    }

    private IEnumerable<HikePoint> StartPoints => Graph.FindVertices(p => p.Value == 0);

    private IEnumerable<ICollection<HikePoint>> FindTrails()
    {
        return StartPoints.SelectMany(start => FindTrails(start, new List<HikePoint>()));
    }

    private IEnumerable<ICollection<HikePoint>> FindTrails(HikePoint start, ICollection<HikePoint> path)
    {
        path.Add(start);
        if (start.Value == 9)
        {
            yield return path;
            yield break;
        }

        var neighbors = Graph.GetNeighbors(start);
        foreach (var neighbor in neighbors)
        {
            var newPath = new List<HikePoint>(path);
            foreach (var p in FindTrails(neighbor.Vertex, newPath))
            {
                yield return p;
            }
        }
    }

    private static List<HikePoint> Trailheads(IEnumerable<ICollection<HikePoint>> trails) =>
        trails.Select(p => p.First()).Distinct().ToList();

    private int Score() => _trailheads
        .Sum(th => _trails
            .Where(t => t.First() == th)
            .Select(t => t.Last()).Distinct().Count());

    private int Rating() => _trailheads
        .Sum(th => _trails.Count(t => t.First() == th));

    public override string Part1()
        => Score().ToString();

    public override string Part2()
        => Rating().ToString();
}