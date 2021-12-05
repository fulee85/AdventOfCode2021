namespace Day05_HydrothermalVenture;

public class Point
{
    public int X { get; init; }
    public int Y { get; init; }
    public int Count { get; private set; }

    public Point()
    {
        Count = 1;
    }

    public override int GetHashCode()
    {
        return X ^ Y;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is not Point other)
            return false;

        return X == other.X && Y == other.Y;
    }

    public void IncrementCount() => Count++;
}
