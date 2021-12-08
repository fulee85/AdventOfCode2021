namespace Day08_SevenSegmentSearch
{
    public class FourDigitDisplay
    {
        private List<Digit> fourDigits;

        public FourDigitDisplay(string digits)
        {
            fourDigits = digits.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(ds => new Digit(ds)).ToList();
        }

        public int GetEasyDigitsCount()
        {
            return fourDigits.Count(d => d.IsEasyDigit());
        }

        public int GetValue(Dictionary<char, char> segmentMapping)
        {
            var result = 0;
            foreach (var digit in fourDigits)
            {
                result *= 10;
                result += digit.CalculateDigitValue(segmentMapping); 
            }

            return result;
        }
    }
}
