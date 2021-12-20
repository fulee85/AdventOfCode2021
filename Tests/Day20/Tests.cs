using Day20_TrenchMap;

namespace Tests.Day20
{
    public class Tests
    {
        private static readonly IEnumerable<string> input = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###".Split(Environment.NewLine);

        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartOne();

            // Assert
            result.Should().Be("35");
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var solver = new Solver(input);

            // Act
            var result = solver.SolvePartTwo();

            // Assert
            result.Should().Be("3351");
        }
    }
}
