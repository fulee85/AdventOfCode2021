namespace Day08_SevenSegmentSearch
{
    public class Segment
    {
        private readonly HashSet<char> possibleMapping = new HashSet<char>("abcdefg");

        public void SetPossibleMapping(IEnumerable<char> chars)
        {
            possibleMapping.IntersectWith(chars);
        }

        public void SetNotPossibleMapping(IEnumerable<char> chars)
        {
            possibleMapping.ExceptWith(chars);
        }

        public bool IsMappingUnambiguous => possibleMapping.Count == 1;

        public char GetValue()
        {
            return possibleMapping.FirstOrDefault();
        }
    }
}
