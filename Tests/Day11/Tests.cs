using Day11_DumboOctopus;
using FluentAssertions;
using System;
using Xunit;

namespace Tests.Day10.Day11
{
    public class Tests
    {
        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

            var octopusSwarm = new OctopusSwarm(input.Split(Environment.NewLine));

            // Act
            var result = octopusSwarm.GetFlashCount(100);

            // Assert
            result.Should().Be(1656);
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

            var octopusSwarm = new OctopusSwarm(input.Split(Environment.NewLine));

            // Act
            var result = octopusSwarm.FirstStepWhenAllOctopusFlashes();

            // Assert
            result.Should().Be(195);
        }
    }
}
