using Day17_TrickShot;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Day17
{
    public class Tests
    {
        private static readonly IEnumerable<string> input = @"target area: x=20..30, y=-10..-5".Split(Environment.NewLine);

        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartOne();

            // Assert
            result.Should().Be("45");
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartTwo();

            // Assert
            result.Should().Be("112");
        }
    }
}
