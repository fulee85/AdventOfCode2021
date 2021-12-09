using Day09_SmokeBasin;

var input = File.ReadLines("input.txt");

var heightMap = new HeightMap(input);

var sum = heightMap.GetLowPointsHeights().Sum(i => i + 1);

Console.WriteLine($"{sum} the sum of the risk levels of all low points on your heightmap.");

var result = heightMap.GetBasinSizes().OrderByDescending(x => x).Take(3).Aggregate((x,y) => x * y);

Console.WriteLine($"If you multiply together the sizes of the three largest basins you get: {result}.");