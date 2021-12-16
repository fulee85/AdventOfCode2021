namespace Day14_ExtendedPolymerization
{
    public class Solver
    {
        private readonly LinkedList<char> polymerTemplate;
        private readonly Dictionary<string, char> polymerizationRules = new Dictionary<string, char>();

        public Solver(IEnumerable<string> input)
        {
            polymerTemplate = new LinkedList<char>(input.First());

            foreach (var rule in input.Skip(2))
            {
                var ruleParts = rule.Split(" -> ");
                polymerizationRules.Add(ruleParts[0], ruleParts[1].FirstOrDefault());
            }
        }

        public string SolvePartOne()
        {
            return GetSolution(10);
        }

        public string SolvePartTwo()
        {
            return GetSolution(40);
        }

        private string GetSolution(int loop)
        {
            var firstElement = polymerTemplate.First;
            Dictionary<char, long> result = new Dictionary<char, long>().Increment(firstElement.Value);
            while (firstElement.Next != null)
            {
                var node = new PolymerNode(firstElement.Value, firstElement.Next.Value, loop);
                result = result.Add(node.GetResultDictionary(polymerizationRules).Decrement(firstElement.Value));
                firstElement = firstElement.Next;
            }

            var max = result.Values.Max();
            var min = result.Values.Min();

            return (max - min).ToString();
        }
    }
}
