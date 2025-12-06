using System.Text;

namespace Day2;

public static class EnumerableExtensions
{
    public static IEnumerable<long> GetInvalidIds1(this IEnumerable<(long, long)> ranges)
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

    public static IEnumerable<string> GetInvalidIds2(this IEnumerable<(string, string)> ranges)
    {
        foreach (var range in ranges)
        {
            var start = new StringBuilder(range.Item1);
            var end = new StringBuilder(range.Item2);
            end.Increment();
            for (var sb = start; sb.ToString() != end.ToString(); sb.Increment())
            {
                var s = sb.ToString();
                for (var n = 1; n <= s.Length / 2; n++)
                {
                    var ss0 = s[..n];
                    if (IsInvalid(s, n, ss0))
                    {
                        yield return s;
                    }
                }
            }
        }
    }

    private static bool IsInvalid(string s, int n, string ss0)
    {
        if (s.Length % n != 0)
            return false;
        for (var i = n; i < s.Length; i += n)
        {
            var ss = s[i..(i + n)];
            if (ss != ss0)
                return false;
        }
        return true;
    }

    private static void Increment(this StringBuilder number)
    {
        var i = number.Length - 1;
        number[i] = Increment(number[i]);
        
        // Handle carry
        while (i > 0 && number[i] == '0')
        {
            i--;
            number[i] = Increment(number[i]);
        }
        if (number[0] == '0')
            number.Insert(0, '1');
    }

    private static char Increment(char digit) => 
        digit == '9' ? '0' : (char)(digit + 1);
}