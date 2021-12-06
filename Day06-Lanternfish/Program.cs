using Day06_Lanternfish;

var input = File.ReadAllText("input.txt").Split(',').Select(int.Parse);

var days = 256;

var lanternfishSwarm = new LanternfishSwarm(input, days);

Console.WriteLine($"{lanternfishSwarm.RunSimulation()} lanternfish would there be after {days} days.");