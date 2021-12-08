namespace Day08_SevenSegmentSearch
{
    public class SegmentMappingCalculator
    {
        private readonly IEnumerable<SignalPattern> signalPatterns;

        public SegmentMappingCalculator(IEnumerable<SignalPattern> signalPatterns)
        {
            this.signalPatterns = signalPatterns;
        }

        public Dictionary<char, char> CalculateSegmentsMapping()
        {
            var mapping = new Dictionary<char, Segment>
            {
                { 'a' , new Segment() },
                { 'b' , new Segment() },
                { 'c' , new Segment() },
                { 'd' , new Segment() },
                { 'e' , new Segment() },
                { 'f' , new Segment() },
                { 'g' , new Segment() },
            };

            foreach (var signalPattern in signalPatterns)
            {
                signalPattern.UpdateMapping(mapping);
            }

            return mapping.ToDictionary(kv => kv.Value.GetValue(), kv => kv.Key);
        }
    }
}
