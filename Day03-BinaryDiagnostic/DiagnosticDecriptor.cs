namespace Day03_BinaryDiagnostic
{
    public class DiagnosticDecriptor
    {
        private readonly List<BinaryNumber> input;

        public DiagnosticDecriptor(IEnumerable<string> input)
        {
            this.input = input.Select(s => new BinaryNumber(s)).ToList();
        }

        public int GetPowerConsumption()
        {
            var binLength = input[0].Length;
            var oneCounts = new int[binLength];

            foreach (var binNum in input)
            {
                for (int i = 0; i < binNum.Length; i++)
                {
                    if (binNum.IsOneInPosition(i))
                    {
                        oneCounts[i]++;
                    }
                    else
                    {
                        oneCounts[i]--;
                    }
                }
            }

            var gammaRate = new BinaryNumber();
            var epsilonRate = new BinaryNumber();
            for (int i = 0; i < oneCounts.Length; i++)
            {
                if (oneCounts[i] > 0)
                {
                    gammaRate.AddDigit(1);
                    epsilonRate.AddDigit(0);
                }
                else
                {
                    gammaRate.AddDigit(0);
                    epsilonRate.AddDigit(1);
                }
            }

            return checked(gammaRate.GetDecimalValue() * epsilonRate.GetDecimalValue());
        }

        public int GetLifeSupportRating()
        {
            return checked(GetOxygenGeneratorRating() * GetCO2ScrubberRating());
        }

        private int GetOxygenGeneratorRating() 
            => GetFilteredValue((containsOneInPosition, containsZeroInPosition)
                => containsOneInPosition.Count >= containsZeroInPosition.Count ? containsOneInPosition : containsZeroInPosition);

        private int GetCO2ScrubberRating() 
            => GetFilteredValue((containsOneInPosition, containsZeroInPosition)
                => containsOneInPosition.Count < containsZeroInPosition.Count ? containsOneInPosition : containsZeroInPosition);

        private int GetFilteredValue(Func<List<BinaryNumber>, List<BinaryNumber>, List<BinaryNumber>> filterRule)
        {
            var containsOneInPosition = new List<BinaryNumber>();
            var containsZeroInPosition = new List<BinaryNumber>();
            var possibleRatingValues = input;
            var positionUnderCheck = 0;

            while (possibleRatingValues.Count > 1)
            {
                foreach (var item in possibleRatingValues)
                {
                    if (item.IsOneInPosition(positionUnderCheck))
                    {
                        containsOneInPosition.Add(item);
                    }
                    else
                    {
                        containsZeroInPosition.Add(item);
                    }
                }

                possibleRatingValues = filterRule(containsOneInPosition, containsZeroInPosition);
                containsOneInPosition = new List<BinaryNumber>();
                containsZeroInPosition = new List<BinaryNumber>();
                positionUnderCheck++;
            }

            return possibleRatingValues.First().GetDecimalValue();
        }
    }
}
