namespace Day1;

public static class EnumerableExtensions
{
    public static int CountZeroRotations(this int[] rotations, int seed = 50)
    {
        var accRotations = rotations.CumulativeSum(seed).ToArray();
        var zeroesCount = accRotations.Count(a => a == 0);
        return zeroesCount;
    }

    private static IEnumerable<int> CumulativeSum(this IEnumerable<int> numbers, int seed)
    {
        var sum = seed;
        foreach (var number in numbers)
        {
            sum = (sum + number) % 100;
            yield return sum;
        }
    }
    
    public static int CountZeroClicks(this IList<int> numbers, int seed = 50)
    {
        var count = 0;
        var last = seed;
        foreach (var number in numbers)
        {
            if (number > 0)
            {
                for (var i = 1; i <= number; i++)
                {
                    if (last % 100 == 0) count++;
                    last++;
                }
            }
            else if (number < 0)
            {
                for (var i = -1; i >= number; i--)
                {
                    if (last % 100 == 0) count++;
                    last--;
                }
            }
        }

        return count;
    }
}