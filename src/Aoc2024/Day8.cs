namespace Aoc2024;

public class Day8(string? input = null) : Day(input)
{
    private Grid<char> _grid;
    private readonly Dictionary<char, List<Point>> _antennas = new();

    protected override void ParseInput()
    {
        _grid = Input.ToGrid();
        for (var y = 0; y < _grid.Height; y++)
        {
            for (var x = 0; x < _grid.Width; x++)
            {
                var c = _grid[x, y];
                if (c == '.') continue;
                if (!_antennas.TryGetValue(c, out var value))
                {
                    value = ( [new Point(x, y)]);
                    _antennas[c] = value;
                }
                else
                {
                    value.Add(new Point(x, y));
                }
            }
        }
    }

    private HashSet<Point> GetAntinodeCoordinates2()
    {
        HashSet<Point> result = [];
        foreach (var frequency in _antennas.Keys)
        {
            var antennas = _antennas[frequency];
            foreach (var pair in Helpers.Combinations(antennas, 2))
            {
                var p0 = pair[0];
                var p1 = pair[1];
                var dx = p1.X - p0.X;
                var dy = p1.Y - p0.Y;
                var dxdy = new Point(dx, dy);
                if (dxdy == Point.Zero)
                {
                    throw new InvalidOperationException("dxdy is zero for some reason");
                }
                var ap = p0;
                while (true)
                {
                    ap += dxdy;
                    if (!_grid.IsInBounds(ap))
                    {
                        break;
                    }

                    result.Add(ap);
                }

                ap = p1;
                while (true)
                {
                    ap -= dxdy;
                    if (!_grid.IsInBounds(ap))
                    {
                        break;
                    }

                    result.Add(ap);
                }
            }
        }

        return result;
    }

    private HashSet<Point> GetAntinodeCoordinates()
    {
        HashSet<Point> result = [];
        foreach (var frequency in _antennas.Keys)
        {
            var antennas = _antennas[frequency];
            foreach (var pair in Helpers.Combinations(antennas, 2))
            {
                var p0 = pair[0];
                var p1 = pair[1];
                var dx = p1.X - p0.X;
                var dy = p1.Y - p0.Y;

                var a1 = p1 + new Point(dx, dy);
                var a0 = p0 + new Point(-dx, -dy);
                if (_grid.IsInBounds(a1))
                {
                    result.Add(a1);
                }

                if (_grid.IsInBounds(a0))
                {
                    result.Add(a0);
                }
            }
        }

        return result;
    }


    public override string Part1()
        => GetAntinodeCoordinates().Count.ToString();

    public override string Part2()
        => GetAntinodeCoordinates2().Count.ToString();
}