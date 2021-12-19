using Day19_BeaconScanner;
using System.Diagnostics;

var sw = Stopwatch.StartNew();
var solver = new Solver(File.ReadLines("input.txt"));
Console.WriteLine(solver.SolvePartOne());
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");
var solver2 = new Solver(File.ReadLines("input.txt"));
Console.WriteLine(solver2.SolvePartTwo());
