using Day20TrenchMap;

namespace Day20_TrenchMap
{
    public class Solver
    {
        private readonly string algorithmString;
        private readonly List<List<char>> inputChars;
        public Solver(IEnumerable<string> input)
        {
            var inputList = input.ToList();

            algorithmString = inputList[0];
            inputChars = inputList.Skip(2).Select(line => line.ToList()).ToList();
        }

        public string SolvePartOne()
        {
            var imageAlgorithm = new ImageEnhancementAlgorithm(algorithmString);
            var image = new Image(inputChars, '.');

            for (int i = 0; i < 2; i++)
            {
                image = imageAlgorithm.EnhanceImage(image);
            }

            return image.GetLitPixelsCount().ToString();
        }

        public string SolvePartTwo()
        {
            var imageAlgorithm = new ImageEnhancementAlgorithm(algorithmString);
            var image = new Image(inputChars, '.');

            for (int i = 0; i < 50; i++)
            {
                image = imageAlgorithm.EnhanceImage(image);
            }

            return image.GetLitPixelsCount().ToString();
        }
    }
}
