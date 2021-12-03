namespace Day03_BinaryDiagnostic
{
    public class BinaryNumber
    {
        private string binaryString;

        public BinaryNumber()
        {
            binaryString = string.Empty;
        }

        public BinaryNumber(string binaryString)
        {
            this.binaryString = binaryString;
        }

        public bool IsOneInPosition(int position) => binaryString[position] == '1';

        public int GetDecimalValue()
        {
            return Convert.ToInt32(binaryString, fromBase: 2);
        }

        public void AddDigit(int digit) => binaryString += digit.ToString();

        public int Length => binaryString.Length;
    }
}
