using Day04_GiantSquid;

var input = File.ReadLines("input.txt");

var bingoGame = new BingoGame(input);

//Console.WriteLine($"Bingo result: {bingoGame.GetFirstWinningTableResult()}");
Console.WriteLine($"Bingo result: {bingoGame.GetLastWinningTableResult()}");
