namespace Day05_HydrothermalVenture;

public class VerticalLine : Line
{
    public VerticalLine(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
    {
        if (x1 != x2)
        {
            throw new ArgumentException("Line not vertical!");
        }
    }

    public override IEnumerable<(int x, int y)> GetCoveredPoints()
    {
        var yStart = Math.Min(y1, y2);
        var yEnd = Math.Max(y1, y2);
        for (int y = yStart; y <= yEnd; y++)
        {
            yield return (x: x1, y: y);
        }
    }
}
