namespace Aoc2024;

public class Day6(string? input = null) : Day(input)
{
    private const char Guard = '^';
    private const char Wall = '#';
    private const char Empty = '.';
    private Grid<char> Map { get; set; }
    private Grid<bool> Map2 { get; set; }
    private Point _guardPosition;

    protected override void ParseInput()
    {
        Map = Input.ToGrid();
        _guardPosition = Map.Find(Guard) ?? throw new InvalidOperationException("Guard not found");
        Map2 = Input.ToGrid(c => c == Wall);
    }

    public override string Part1()
    {
        var visited = new HashSet<int>((int)(Map.Width * Map.Height));
        var facing = CardinalDirection.North;
        var pos = Map.Find(Guard);
        if (pos is null)
        {
            throw new InvalidOperationException("Guard not found");
        }

        var position = pos.Value;
        visited.Add(position.GetHashCode());
        while (true)
        {
            var next = position.Move(facing);
            if (!Map.IsInBounds(next))
            {
                break;
            }

            switch (Map[next.X, next.Y])
            {
                case Guard:
                case Empty:
                    position = next;
                    visited.Add(position.GetHashCode());
                    continue;
                case Wall:
                    facing = facing.TurnRight();
                    break;
            }
        }

        return visited.Count.ToString();
    }

    public override string Part2()
        => GetPermutations().AsParallel().Count((g) => HasLoop(g, _guardPosition)).ToString();


    private static bool HasLoop(Grid<bool> map, Point start)
    {
        var visited = new HashSet<int>((int)(map.Width * map.Height));
        var facing = CardinalDirection.North;
        var position = start;
        visited.Add(HashCode.Combine(position, facing));
        while (true)
        {
            var next = position.Move(facing);
            if (!map.IsInBounds(next))
            {
                return false;
            }

            switch (map[next.X, next.Y])
            {
                case false:
                    position = next;
                    if (!visited.Add(HashCode.Combine(position, facing)))
                    {
                        return true;
                    }

                    continue;
                case true:
                    facing = facing.TurnRight();
                    break;
            }
        }
    }

    private IEnumerable<Grid<bool>> GetPermutations()
    {
        var emptyPositions = Map.Data.Select((c, i) => (c, i)).Where(x => x.c == Empty)
            .Select(x => new Point(x.i % Map.Width, x.i / Map.Width)).ToHashSet();
        foreach (var pos in emptyPositions)
        {
            var map = Map2.Clone();
            map[pos.X, pos.Y] = true;
            yield return map;
        }
    }
}