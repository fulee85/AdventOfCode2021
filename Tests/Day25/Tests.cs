using Day25_SeaCucumber;

namespace Tests.Day25
{
    public class Tests
    {
        private static readonly IEnumerable<string> input = @"v...>>.vv>
.vv>>.vv..
>>.>v>...v
>>v>>.>.v.
v>v.vv.v..
>.>>..v...
.vv..>.>v.
v.v..>>v.v
....v..v.>".Split(Environment.NewLine);

        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartOne();

            // Assert
            result.Should().Be("58");
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartTwo();

            // Assert
            result.Should().Be("");
        }
    }
}
