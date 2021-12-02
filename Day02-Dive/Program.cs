using Day02_Dive;

var instructions = File.ReadLines("input.txt");

var submarine1 = new FirstSubmarine();
var submarine2 = new SecondSubmarine();

foreach (var instruction in instructions)
{
    var instructionParts = instruction.Split(' ');
    var command = instructionParts[0];
    var value = int.Parse(instructionParts[1]);
    submarine1.Run(command, value);
    submarine2.Run(command, value);
}


Console.WriteLine($"Multiply final horizontal position by your final depth results for submarine 1: {submarine1.Position}");
Console.WriteLine($"Multiply final horizontal position by your final depth results for submarine 2: {submarine2.Position}");