using Day18Snailfish;

namespace Day18_Snailfish
{
    public class Solver
    {
        private List<string> input;
        private IEnumerable<SnailfishNumber> snailfishNumbers;

        public Solver(IEnumerable<string> input)
        {
            this.input = input.ToList();
            snailfishNumbers = input.Select(s => Day18Snailfish.SnailfishNumber.Create(s)).ToList();
        }

        public string SolvePartOne()
        {
            var sum = snailfishNumbers.First();
            foreach (var num in snailfishNumbers.Skip(1))
            {
                sum += num;
            }

            return sum.GetMagnitude().ToString();
        }

        public string SolvePartTwo()
        {
            var max = long.MinValue;
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (i != j)
                    {
                        var x = SnailfishNumber.Create(input[i]);
                        var y = SnailfishNumber.Create(input[j]);
                        var z = x + y;
                        if (z.GetMagnitude() > max)
                        {
                            max = z.GetMagnitude();
                        }
                    }
                }
            }

            return max.ToString();
        }
    }
}
