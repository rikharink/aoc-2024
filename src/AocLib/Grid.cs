namespace AocLib;

public readonly struct Grid<T> : IEquatable<Grid<T>>
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

    public T this[Point p]
    {
        get => this[p.X, p.Y];
        set => this[p.X, p.Y] = value;
    }

    public T this[long x, long y]
    {
        get => Data[y * Width + x];
        set => Data[y * Width + x] = value;
    }

    public Point? Find(T element)
    {
        var index = Array.IndexOf(Data, element);
        if (index == -1)
        {
            return null;
        }

        return new Point(index % Width, index / Width);
    }

    public IEnumerable<Point> FindAll(Func<T, bool> predicate)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (predicate(this[x, y]))
                {
                    yield return new Point(x, y);
                }
            }
        }
    }

    public bool IsInBounds(Point location)
        => location.X >= 0 && location.X < Width && location.Y >= 0 && location.Y < Height;

    public IEnumerable<T> GetDiagonalNeighbours(Point location)
    {
        var upleft = location.Move(Direction.UpLeft);
        var upright = location.Move(Direction.UpRight);
        var downleft = location.Move(Direction.DownLeft);
        var downright = location.Move(Direction.DownRight);

        if (upleft.X >= 0 && upleft.X < Width && upleft.Y >= 0 && upleft.Y < Height)
        {
            yield return this[upleft];
        }

        if (upright.X >= 0 && upright.X < Width && upright.Y >= 0 && upright.Y < Height)
        {
            yield return this[upright];
        }

        if (downleft.X >= 0 && downleft.X < Width && downleft.Y >= 0 && downleft.Y < Height)
        {
            yield return this[downleft];
        }

        if (downright.X >= 0 && downright.X < Width && downright.Y >= 0 && downright.Y < Height)
        {
            yield return this[downright];
        }
    }

    public IEnumerable<Point> GetNeighbourLocations(Point location, bool includeDiagonal = false)
    {
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
                if (IsInBounds(neighbour))
                {
                    yield return neighbour;
                }
            }
        }
    }

    public IEnumerable<T> GetNeighbours(Point location, bool includeDiagonal = false)
    {
        foreach (var n in GetNeighbourLocations(location, includeDiagonal))
        {
            yield return this[n];
        }
    }

    public IEnumerable<T> GetRun(Point start, Direction direction, long length, bool shouldWrap = false)
    {
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

            yield return this[current];
            current = current.Move(direction);
        }
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

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj.GetType() == GetType() && Equals((Grid<T>)obj);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Width);
        hash.Add(Height);
        foreach (var item in Data)
        {
            hash.Add(item);
        }

        return hash.ToHashCode();
    }

    public static bool operator ==(Grid<T>? left, Grid<T>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Grid<T>? left, Grid<T>? right)
    {
        return !Equals(left, right);
    }

    public bool Equals(Grid<T> other)
    {
        return Width == other.Width && Height == other.Height && Data.SequenceEqual(other.Data);
    }

    public bool Equals(Grid<T>? other)
    {
        if (other is null) return false;
        return Width == other.Value.Width && Height == other.Value.Height && Data.SequenceEqual(other.Value.Data);
    }
}