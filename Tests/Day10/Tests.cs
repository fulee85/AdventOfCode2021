using Day10_SyntaxScoring;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Day10
{
    public class Tests
    {
        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

            var chunkLines = input.Split(Environment.NewLine).Select(sl => new ChunkLine(sl));

            // Act
            var result = Scorer.CalculateScore(chunkLines);

            // Assert
            result.Should().Be(26397);
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

            var chunkLines = input.Split(Environment.NewLine).Select(sl => new ChunkLine(sl));

            // Act
            var result = Scorer.CalculateCompletionScore(chunkLines);

            // Assert
            result.Should().Be(288957);
        }
    }
}
