namespace Day08_SevenSegmentSearch
{
    public class Entry
    {
        private readonly List<SignalPattern> signals;
        private readonly FourDigitDisplay fourDigitDisplay;

        public Entry(string inputLine)
        {
            var inputParts = inputLine.Split(new char[] { '|' });
            signals = inputParts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => new SignalPattern(s)).ToList();
            fourDigitDisplay = new FourDigitDisplay(inputParts[1]);
        }

        public int GetOutputValue()
        {
            var mappingCalculator = new SegmentMappingCalculator(signals);
            var mapping = mappingCalculator.CalculateSegmentsMapping();

            return fourDigitDisplay.GetValue(mapping);
        }

        public int GetEasyDigitsAppearCount()
        {
            return fourDigitDisplay.GetEasyDigitsCount();
        }
    }
}
