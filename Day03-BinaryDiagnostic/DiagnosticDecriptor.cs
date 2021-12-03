namespace Day03_BinaryDiagnostic;

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
        var gammaRate = new BinaryNumber();
        var epsilonRate = new BinaryNumber();

        for (int i = 0; i < binLength; i++)
        {
            SeparateBinaryNumbersByDigitInPosition(i, input, out var containsOneInPosition, out var containsZeroInPosition);
            if (containsOneInPosition.Count > containsZeroInPosition.Count)
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
        => GetRatingValue((containsOneInPosition, containsZeroInPosition)
            => containsOneInPosition.Count >= containsZeroInPosition.Count ? containsOneInPosition : containsZeroInPosition);
    private int GetCO2ScrubberRating() 
        => GetRatingValue((containsOneInPosition, containsZeroInPosition)
            => containsOneInPosition.Count < containsZeroInPosition.Count ? containsOneInPosition : containsZeroInPosition);

    private int GetRatingValue(Func<List<BinaryNumber>, List<BinaryNumber>, List<BinaryNumber>> rule)
    {
        var itemsUnderCheck = input;
        var positionUnderCheck = 0;

        while (itemsUnderCheck.Count > 1)
        {
            SeparateBinaryNumbersByDigitInPosition(positionUnderCheck, itemsUnderCheck, out var containsOneInPosition, out var containsZeroInPosition);
            itemsUnderCheck = rule(containsOneInPosition, containsZeroInPosition);
            positionUnderCheck++;
        }

        return itemsUnderCheck.First().GetDecimalValue();
    }

    private static void SeparateBinaryNumbersByDigitInPosition(
        int position,
        List<BinaryNumber> items,
        out List<BinaryNumber> containsOneInPosition,
        out List<BinaryNumber> containsZeroInPosition)
    {
        containsZeroInPosition = new List<BinaryNumber>();
        containsOneInPosition = new List<BinaryNumber>();

        foreach (var item in items)
        {
            if (item.IsOneInPosition(position))
            {
                containsOneInPosition.Add(item);
            }
            else
            {
                containsZeroInPosition.Add(item);
            }
        }
    }
}