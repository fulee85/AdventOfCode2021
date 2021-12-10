using Day10_SyntaxScoring;

var chunkLines = File.ReadLines("input.txt").Select(sl => new ChunkLine(sl)).ToList();
var score = Scorer.CalculateScore(chunkLines);

Console.WriteLine($"The total syntax error score for those errors is: {score}");

var completionScore = Scorer.CalculateCompletionScore(chunkLines);

Console.WriteLine($"The completion score is: {completionScore}");