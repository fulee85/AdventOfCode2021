using Day21_DiracDice;

namespace Tests.Day21
{
    public class Tests
    {
        private static readonly IEnumerable<string> input = @"Player 1 starting position: 4
Player 2 starting position: 8".Split(Environment.NewLine);

        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartOne();

            // Assert
            result.Should().Be("739785");
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartTwo();

            // Assert
            result.Should().Be("444356092776315");
        }
    }
}
