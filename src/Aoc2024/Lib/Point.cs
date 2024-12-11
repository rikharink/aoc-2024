namespace Aoc2024.Lib;

public readonly record struct PointD(double X, double Y)
{
    public static PointD operator +(PointD a, PointD b) => new(a.X + b.X, a.Y + b.Y);
    public static PointD operator -(PointD a, PointD b) => new(a.X - b.X, a.Y - b.Y);
    public static PointD operator *(PointD a, double b) => new(a.X * b, a.Y * b);
    public static PointD operator /(PointD a, double b) => new(a.X / b, a.Y / b);

    public static implicit operator PointD((double X, double Y) tuple) => new(tuple.X, tuple.Y);
    public static implicit operator (double X, double Y)(PointD point) => (point.X, point.Y);
    public static PointD Zero => new(0, 0);
    public double ManhattanDistance(PointD other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    public static double ManhattanDistance(PointD a, PointD b) => a.ManhattanDistance(b);
    public override string ToString() => $"({X}, {Y})";
}

public readonly record struct Point(long X, long Y)
{
    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
    public static Point operator -(Point a, Point b) => new(a.X - b.X, a.Y - b.Y);
    public static Point operator *(Point a, long b) => new(a.X * b, a.Y * b);
    public static Point operator /(Point a, long b) => new(a.X / b, a.Y / b);

    public static implicit operator Point((long X, long Y) tuple) => new(tuple.X, tuple.Y);
    public static implicit operator (long X, long Y)(Point point) => (point.X, point.Y);
    public static Point Zero => new(0, 0);

    public long ManhattanDistance(Point other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    public static long ManhattanDistance(Point a, Point b) => a.ManhattanDistance(b);

    public Point Move(CardinalDirection direction) => direction switch
    {
        CardinalDirection.North => this with { Y = Y - 1 },
        CardinalDirection.South => this with { Y = Y + 1 },
        CardinalDirection.West => this with { X = X - 1 },
        CardinalDirection.East => this with { X = X + 1 },
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };

    public Point Move(Direction direction) => direction switch
    {
        Direction.Up => this with { Y = Y - 1 },
        Direction.Down => this with { Y = Y + 1 },
        Direction.Left => this with { X = X - 1 },
        Direction.Right => this with { X = X + 1 },
        Direction.UpLeft => new Point(X: X - 1, Y: Y - 1),
        Direction.UpRight => new Point(X: X + 1, Y: Y - 1),
        Direction.DownLeft => new Point(X: X - 1, Y: Y + 1),
        Direction.DownRight => new Point(X: X + 1, Y: Y + 1),
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };

    public override string ToString() => $"({X}, {Y})";
}