namespace Day05_HydrothermalVenture;

public abstract class Line
{
    protected int x1, y1, x2, y2;

    public Line(int x1, int y1, int x2, int y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public abstract IEnumerable<(int x, int y)> GetCoveredPoints();

    public static Line Create(string input)
    {
        var pointCoordinates = input.Split(" -> ");
        var startCoordinate = pointCoordinates[0].Split(',');
        var endCoordinate = pointCoordinates[1].Split(',');
        var x1 = int.Parse(startCoordinate[0]);
        var y1 = int.Parse(startCoordinate[1]);
        var x2 = int.Parse(endCoordinate[0]);
        var y2 = int.Parse(endCoordinate[1]);

        if (x1 == x2)
        {
            return new VerticalLine(x1, y1, x2, y2);
        }
        else if (y1 == y2)
        {
            return new HorizontalLine(x1, y1, x2, y2);
        }
        else
        {
            return new DiagonalLine(x1, y1, x2, y2);
        }
    }
}
