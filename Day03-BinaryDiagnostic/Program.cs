using Day03_BinaryDiagnostic;

var input = File.ReadLines("input.txt");

var decriptor = new DiagnosticDecriptor(input);

Console.WriteLine($"The power consumption of the submarine is {decriptor.GetPowerConsumption()}");
Console.WriteLine($"The life support rating of the submarine is {decriptor.GetLifeSupportRating()}");