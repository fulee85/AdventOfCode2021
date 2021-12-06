using Day06_Lanternfish;
using FluentAssertions;
using Xunit;

namespace Tests.Day06
{
    public class Tests
    {
        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var input = new int[] { 3, 4, 3, 1, 2 };

            var lanternfishSwarm = new LanternfishSwarm(input, 80);

            // Act
            var result = lanternfishSwarm.RunSimulation();

            // Assert
            result.Should().Be(5934);
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var input = new int[] { 3, 4, 3, 1, 2 };

            var lanternfishSwarm = new LanternfishSwarm(input, 256);

            // Act
            var result = lanternfishSwarm.RunSimulation();

            // Assert
            result.Should().Be(26984457539);
        }
    }
}