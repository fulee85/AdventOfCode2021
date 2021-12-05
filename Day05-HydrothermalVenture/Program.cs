using Day05_HydrothermalVenture;

var input = File.ReadLines("input.txt").Select(Line.Create).ToList();

// var oceanFloor = new OceanFloor(input.Where(l => l is not DiagonalLine));
var oceanFloor = new OceanFloor(input);
var result = oceanFloor.GetCountOfPointsWhereAtLeastTwoLinesOverlap();

Console.WriteLine($"At {result} points do at least two lines overlap.");