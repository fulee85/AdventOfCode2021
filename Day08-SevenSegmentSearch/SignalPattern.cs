namespace Day08_SevenSegmentSearch
{
    public class SignalPattern
    {
        private readonly string signal;

        public SignalPattern(string signal)
        {
            this.signal = signal;
        }

        ///  aaaa
        /// b    c
        /// b    c
        ///  dddd
        /// e    f
        /// e    f
        ///  gggg
        public void UpdateMapping(Dictionary<char, Segment> mapping)
        {
            if (signal.Length == 2)
            /// 1 -> 2 length "cf"
            {
                mapping['c'].SetPossibleMapping(signal);
                mapping['f'].SetPossibleMapping(signal);
                mapping['a'].SetNotPossibleMapping(signal);
                mapping['b'].SetNotPossibleMapping(signal);
                mapping['d'].SetNotPossibleMapping(signal);
                mapping['e'].SetNotPossibleMapping(signal);
                mapping['g'].SetNotPossibleMapping(signal);
            }
            else if (signal.Length == 3)
            /// 7 -> 3 length "acf"
            {
                mapping['a'].SetPossibleMapping(signal);
                mapping['c'].SetPossibleMapping(signal);
                mapping['f'].SetPossibleMapping(signal);
                mapping['b'].SetNotPossibleMapping(signal);
                mapping['d'].SetNotPossibleMapping(signal);
                mapping['e'].SetNotPossibleMapping(signal);
                mapping['g'].SetNotPossibleMapping(signal);
            }
            else if (signal.Length == 4)
            /// 4 -> 4 length "bcdf"
            {
                mapping['b'].SetPossibleMapping(signal);
                mapping['c'].SetPossibleMapping(signal);
                mapping['d'].SetPossibleMapping(signal);
                mapping['f'].SetPossibleMapping(signal);
                mapping['a'].SetNotPossibleMapping(signal);
                mapping['e'].SetNotPossibleMapping(signal);
                mapping['g'].SetNotPossibleMapping(signal);
            }
            else if (signal.Length == 5)
            /// 2 -> 5 length "acdeg"
            /// 3 -> 5 length "acdfg"
            /// 5 -> 5 length "abdfg"
            {
                mapping['a'].SetPossibleMapping(signal);
                mapping['d'].SetPossibleMapping(signal);
                mapping['g'].SetPossibleMapping(signal);
            }
            else if (signal.Length == 6)
            /// 0 -> 6 length "abcefg"
            /// 6 -> 6 length "abdefg"
            /// 9 -> 6 length "abcdfg"
            {
                mapping['a'].SetPossibleMapping(signal);
                mapping['b'].SetPossibleMapping(signal);
                mapping['f'].SetPossibleMapping(signal);
                mapping['g'].SetPossibleMapping(signal);
            }

            foreach (KeyValuePair<char, Segment> keyValue in mapping)
            {
                if (keyValue.Value.IsMappingUnambiguous)
                {
                    foreach (var item in mapping.Where(kv => !kv.Value.IsMappingUnambiguous))
                    {
                        item.Value.SetNotPossibleMapping(new[] {keyValue.Value.GetValue()});
                    }
                }
            }
        }
    }
}
