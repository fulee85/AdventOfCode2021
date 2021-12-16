namespace Day16PacketDecoder
{
    public static class EnumerableExtensions
    {
        public static long Product<T>(this IEnumerable<T> input, Func<T, long> selector)
        {
            return input.Select(selector).Aggregate(1L, (a, i) => a * i);
        }
    }
}
