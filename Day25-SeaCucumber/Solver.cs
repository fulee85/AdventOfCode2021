using Day25SeaCucumber;

namespace Day25_SeaCucumber
{
    public class Solver
    {
        private readonly IEnumerable<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }

        public string SolvePartOne()
        {
            var seaFloor = new SeaFloor(input);

            int stepCount = 1;

            while (seaFloor.MakeStep())
            {
                stepCount++;
            }

            return stepCount.ToString();
        }

        public string SolvePartTwo()
        {
            return string.Empty;
        }
    }
}
