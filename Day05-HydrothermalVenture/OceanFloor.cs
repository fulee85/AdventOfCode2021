namespace Day05_HydrothermalVenture;

public class OceanFloor
{
    private readonly IEnumerable<Line> lines;
    private readonly HashSet<Point> points = new();

    public OceanFloor(IEnumerable<Line> lines)
    {
        this.lines = lines;
    }

    public int GetCountOfPointsWhereAtLeastTwoLinesOverlap()
    {
        foreach (var line in lines)
        {
            foreach (var (x, y) in line.GetCoveredPoints())
            {
                var newPoint = new Point { X = x, Y = y };
                if (points.TryGetValue(newPoint, out var point))
                {
                    point.IncrementCount();
                }
                else
                {
                    points.Add(newPoint);
                }
            }
        }

        return points.Count(p => p.Count > 1);
    }
}
