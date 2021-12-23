using Day22ReactorReboot;

namespace Day22_ReactorReboot
{
    public class Solver
    {
        private readonly List<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input.ToList();
        }

        public string SolvePartOne()
        {
            var reactor = new Reactor();

            foreach (var step in input.Select(x => new Cuboid(x)))
            {
                step.ApplyStep(reactor);
            }

            return reactor.OnCubesCount.ToString();
        }

        public string SolvePartTwo()
        {
            var cuboidInput = new List<SmartCuboid>();
            for (int i = 1; i <= input.Count; i++)
            {
                cuboidInput.Add(new SmartCuboid(input[i - 1], i.ToString()));
            }
            var infiniteReactor = new InfiniteReactor(cuboidInput[0]);

            for (int i = 1; i < cuboidInput.Count; i++)
            {
                infiniteReactor.MakeStep(cuboidInput[i]);
            }

            return infiniteReactor.GetOnCubeCount();
        }
    }
}
