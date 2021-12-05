namespace Day05_HydrothermalVenture;

public class DiagonalLine : Line
{
    public DiagonalLine(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
    {
        if (Math.Abs(x2 - x1) != Math.Abs(y2 - y1))
        {
            throw new ArgumentException("Line not diagonal!");
        }
    }

    public override IEnumerable<(int x, int y)> GetCoveredPoints()
    {
        var xAct = x1;
        var yAct = y1;
        var xStep = x2 >= x1 ? 1 : -1;
        var yStep = y2 >= y1 ? 1 : -1;

        while (xAct != x2 && yAct != y2)
        {
            yield return (xAct, yAct);
            xAct += xStep;
            yAct += yStep;
        }

        yield return (x2, y2);
    }
}
