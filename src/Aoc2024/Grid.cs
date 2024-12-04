using System.Text;

namespace Aoc2024;

public class Grid<T>
{
    public long Width { get; }
    public long Height { get; }
    public T[] Data { get; }

    public Grid(long width, long height, T[] data)
    {
        if (width * height != data.Length)
        {
            throw new ArgumentException("Size does not match data length.");
        }

        Width = width;
        Height = height;
        Data = data;
    }

    public T this[long x, long y]
    {
        get => Data[y * Width + x];
        set => Data[y * Width + x] = value;
    }

    public List<T> GetDiagonalNeighbours(Point location)
    {
        var neighbours = new List<T>();
        var upleft = location.Move(Direction.UpLeft);
        var upright = location.Move(Direction.UpRight);
        var downleft = location.Move(Direction.DownLeft);
        var downright = location.Move(Direction.DownRight);

        if (upleft.X >= 0 && upleft.X < Width && upleft.Y >= 0 && upleft.Y < Height)
        {
            neighbours.Add(this[upleft.X, upleft.Y]);
        }

        if (upright.X >= 0 && upright.X < Width && upright.Y >= 0 && upright.Y < Height)
        {
            neighbours.Add(this[upright.X, upright.Y]);
        }

        if (downleft.X >= 0 && downleft.X < Width && downleft.Y >= 0 && downleft.Y < Height)
        {
            neighbours.Add(this[downleft.X, downleft.Y]);
        }

        if (downright.X >= 0 && downright.X < Width && downright.Y >= 0 && downright.Y < Height)
        {
            neighbours.Add(this[downright.X, downright.Y]);
        }


        return neighbours;
    }

    public List<T> GetNeighbours(Point location, bool includeDiagonal = false)
    {
        var neighbours = new List<T>();
        for (var y = -1; y <= 1; y++)
        {
            for (var x = -1; x <= 1; x++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                if (!includeDiagonal && x != 0 && y != 0)
                {
                    continue;
                }

                var neighbour = location + new Point(x, y);
                if (neighbour.X >= 0 && neighbour.X < Width && neighbour.Y >= 0 && neighbour.Y < Height)
                {
                    neighbours.Add(this[neighbour.X, neighbour.Y]);
                }
            }
        }

        return neighbours;
    }

    public List<T> GetRun(Point start, Direction direction, long length, bool shouldWrap = false)
    {
        var run = new List<T>();
        var current = start;
        for (var i = 0; i < length; i++)
        {
            if (current.X < 0 || current.X >= Width || current.Y < 0 || current.Y >= Height)
            {
                if (shouldWrap)
                {
                    current = new Point((current.X + Width) % Width, (current.Y + Height) % Height);
                }
                else
                {
                    break;
                }
            }

            run.Add(this[current.X, current.Y]);
            current = current.Move(direction);
        }

        return run;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                sb.Append(this[x, y]);
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }

    public Grid<T> Clone()
    {
        return new Grid<T>(Width, Height, Data.ToArray());
    }
}