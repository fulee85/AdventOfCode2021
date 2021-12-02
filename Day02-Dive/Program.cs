using Day02_Dive;

var instructions = File.ReadLines("input.txt");

var submarine = new FirstSubmarine();
//var submarine = new SecondSubmarine();
submarine.Run(instructions);
Console.WriteLine($"Multiply your final horizontal position by your final depth results: {submarine.Position}");