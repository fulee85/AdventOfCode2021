using Day07_TheTreacheryOfWhales;

var input = File.ReadAllText("input.txt").Split(',').Select(int.Parse);

var crabSwarm = new CrabSwarm(input);
//var positionToReach = crabSwarm.GetAlignPosition();
//Console.WriteLine($"{crabSwarm.GetFuelConsumtionToPosition(positionToReach)} fuel must they spend to align to that position.");
Console.WriteLine($"{crabSwarm.GetMinFuelConsumption()} fuel must they spend to align to that position.");