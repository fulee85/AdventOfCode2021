using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_SyntaxScoring
{
    public static class Scorer
    {
        public static long CalculateScore(IEnumerable<ChunkLine> chunkLines)
        {
            return chunkLines
                .Where(chunkLines => chunkLines.IsLineCorrupted)
                .Select(chunkLine => chunkLine.CorruptChar)
                .Aggregate(0L, (s, ch) => s + ch switch
                {
                    ')' => 3,
                    ']' => 57,
                    '}' => 1197,
                    '>' => 25137,
                     _  => throw new NotImplementedException()
                });
        }

        public static long CalculateCompletionScore(IEnumerable<ChunkLine> chunkLines)
        {
            var corruptedLines = chunkLines
                .Where(chunkLines => !chunkLines.IsLineCorrupted && chunkLines.IsLineIncomplete);
            var scores = corruptedLines.Select(chunkLine => chunkLine.GetCompletingChars().Aggregate(0L, (l, c) => l * 5 + (c switch
                {
                    ')' => 1,
                    ']' => 2,
                    '}' => 3,
                    '>' => 4,
                    _ => throw new NotImplementedException()
                })))
                .ToList();

            return GetMiddleScore(scores);
        }

        private static long GetMiddleScore(List<long> scores)
        {
            scores.Sort();

            return scores[scores.Count / 2];
        }
    }
}
