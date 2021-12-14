namespace Day14_ExtendedPolymerization
{
    public static class DictionaryExtensions
    {
        public static Dictionary<char, long> Add(this Dictionary<char, long> dict, Dictionary<char, long> other)
        {
            var result = new Dictionary<char, long>(dict);
            foreach (var item in other)
            {
                if (result.ContainsKey(item.Key))
                {
                    result[item.Key] += other[item.Key];
                }
                else
                {
                    result[item.Key] = other[item.Key];
                }
            }

            return result;
        }

        public static Dictionary<char, long> Increment(this Dictionary<char, long> dict, char ch)
        {
            if (dict.ContainsKey(ch))
            {
                dict[ch]++;
            }
            else
            {
                dict.Add(ch, 1);
            }

            return dict;
        }

        public static Dictionary<char, long> Decrement(this Dictionary<char, long> dict, char ch)
        {
            var result = new Dictionary<char, long>(dict);

            result[ch]--;

            return result;
        }
    }
}
