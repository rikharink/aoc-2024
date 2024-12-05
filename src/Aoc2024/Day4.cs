namespace Aoc2024;

public class Day4(string? input = null) : Day<int>(input)
{
    private Grid<char> _xmas = null!;
    private HashSet<Point> _xmasPoints = [];

    protected override void ParseInput()
    {
        var lines = Input.SplitNewLines().ToArray();
        _xmas = new Grid<char>(lines.Length, lines[0].Length, Input.StripNewLines().ToCharArray());
    }

    private string GetRun(Point start, Direction direction, long length) =>
        string.Join("", _xmas.GetRun(start, direction, length));

    private static bool IsXmas(string input) => input is "XMAS" or "SAMX";

    private static bool IsXMas(string input)
    {
        HashSet<string> valid = ["MMSS", "SSMM", "MSMS", "SMSM"];
        return valid.Contains(input);
    }

    public Grid<char> StripNonXmas()
    {
        var grid = _xmas.Clone();
        for (var y = 0; y < _xmas.Height; y++)
        {
            for (var x = 0; x < _xmas.Width; x++)
            {
                if (!_xmasPoints.Contains((x, y)))
                {
                    grid[x, y] = '.';
                }
            }
        }

        return grid;
    }

    public override int Part1()
    {
        _xmasPoints.Clear();
        var found = 0;

        for (var y = 0; y < _xmas.Height; y++)
        {
            for (var x = 0; x < _xmas.Width; x++)
            {
                Point current = (x, y);

                var right = GetRun(current, Direction.Right, 4);
                if (IsXmas(right))
                {
                    _xmasPoints.Add(current);
                    _xmasPoints.Add(current + (1, 0));
                    _xmasPoints.Add(current + (2, 0));
                    _xmasPoints.Add(current + (3, 0));
                    found++;
                }

                var down = GetRun(current, Direction.Down, 4);
                if (IsXmas(down))
                {
                    _xmasPoints.Add(current);
                    _xmasPoints.Add(current + (0, 1));
                    _xmasPoints.Add(current + (0, 2));
                    _xmasPoints.Add(current + (0, 3));
                    found++;
                }

                var downRight = GetRun(current, Direction.DownRight, 4);
                if (IsXmas(downRight))
                {
                    _xmasPoints.Add(current);
                    _xmasPoints.Add(current + (1, 1));
                    _xmasPoints.Add(current + (2, 2));
                    _xmasPoints.Add(current + (3, 3));
                    found++;
                }

                var downLeft = GetRun(current, Direction.DownLeft, 4);
                if (IsXmas(downLeft))
                {
                    _xmasPoints.Add(current);
                    _xmasPoints.Add(current + (-1, 1));
                    _xmasPoints.Add(current + (-2, 2));
                    _xmasPoints.Add(current + (-3, 3));
                    found++;
                }
            }
        }

        return found;
    }

    public override int Part2()
    {
        _xmasPoints.Clear();
        var found = 0;
        for (var y = 0; y < _xmas.Height; y++)
        {
            for (var x = 0; x < _xmas.Width; x++)
            {
                Point current = (x, y);
                if (_xmas[x, y] != 'A' || !IsXMas(string.Join("", _xmas.GetDiagonalNeighbours(current)))) continue;
                _xmasPoints.Add(current);
                _xmasPoints.Add(current.Move(Direction.UpLeft));
                _xmasPoints.Add(current.Move(Direction.UpRight));
                _xmasPoints.Add(current.Move(Direction.DownLeft));
                _xmasPoints.Add(current.Move(Direction.DownRight));
                found++;
            }
        }

        return found;
    }

    public override string ToString()
    {
        return _xmas.ToString();
    }
}