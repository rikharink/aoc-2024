namespace AocLib;

public enum CardinalDirection
{
    North,
    East,
    South,
    West
}

public static class CardinalDirectionExtensions
{
    public static CardinalDirection TurnRight(this CardinalDirection direction)
        => direction switch
        {
            CardinalDirection.North => CardinalDirection.East,
            CardinalDirection.East => CardinalDirection.South,
            CardinalDirection.South => CardinalDirection.West,
            CardinalDirection.West => CardinalDirection.North,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
}