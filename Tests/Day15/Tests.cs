using Day15_Chiton;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Day15
{
    public class Tests
    {
        private static readonly IEnumerable<string> input = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581".Split(Environment.NewLine);

        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartOne();

            // Assert
            result.Should().Be("40");
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartTwo();

            // Assert
            result.Should().Be("315");
        }
    }
}
