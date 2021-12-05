namespace Day05_HydrothermalVenture;

public class HorizontalLine : Line
{
    public HorizontalLine(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
    {
        if (y1 != y2)
        {
            throw new ArgumentException("Line not Horizontal!");
        }
    }

    public override IEnumerable<(int x, int y)> GetCoveredPoints()
    {
        var xStart = Math.Min(x1, x2);
        var xEnd = Math.Max(x1, x2);
        for (int x = xStart; x <= xEnd; x++)
        {
            yield return (x: x, y: y1);
        }
    }
}
