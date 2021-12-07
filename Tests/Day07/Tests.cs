using Day07_TheTreacheryOfWhales;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Tests.Day07
{
    public class Tests
    {
        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
            var avr = input.Average();

            var crabSwarm = new CrabSwarm(input);

            // Act
            var position = crabSwarm.GetAlignPosition();
            var fuelRequired = crabSwarm.GetFuelConsumtionToPosition(position);

            // Assert
            position.Should().Be(2);
            fuelRequired.Should().Be(37);
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
            var avr = input.Average();

            var crabSwarm = new CrabSwarm(input);

            // Act
            var fuelRequired = crabSwarm.GetMinFuelConsumption();

            // Assert
            fuelRequired.Should().Be(168);
        }
    }
}