using Day11_DumboOctopus;

var input = File.ReadLines("input.txt").ToList();

var swarm = new OctopusSwarm(input);
Console.WriteLine($"{swarm.GetFlashCount(100)} total flashes there are after 100 steps.");

var swarmSecond = new OctopusSwarm(input);
Console.WriteLine($"The first step during which all octopuses flash is: {swarmSecond.FirstStepWhenAllOctopusFlashes()}");

