namespace Day2;

public static class EnumerableExtensions
{
    public static IEnumerable<long> GetInvalidIds(this IEnumerable<(long, long)> ranges)
    {
        foreach (var range in ranges)
        {
            for (var n = range.Item1; n <= range.Item2; n++)
            {
                var digitCount = n.CountDigits();
                if (digitCount % 2 == 0)
                {
                    var exponent = (int)(digitCount / 2);
                    var lowPart = (long)(n / Math.Pow(10, exponent));
                    var highPart = (long)(lowPart * Math.Pow(10, exponent));
                    if (n == highPart + lowPart)
                    {
                        yield return n;
                    }
                }
            }
        }
    }
}