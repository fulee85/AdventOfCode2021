using Day13_TransparentOrigami;

var input = File.ReadAllLines("input.txt");

var solver = new Solver(input);

Console.WriteLine($"{solver.SolveFirstPart()} dots are visible after completing just the first fold instruction on your transparent paper.");
Console.WriteLine($"The code you use to activate the infrared thermal imaging camera system is:");
Console.WriteLine(solver.SolveSecondPart());