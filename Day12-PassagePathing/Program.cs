using Day12_PassagePathing;

var input = File.ReadLines("input.txt");
var caves = new Caves(input);

Console.WriteLine($"Ther are {caves.GetExtraPathCount()} paths through this cave system are there that visit small caves at most once");

