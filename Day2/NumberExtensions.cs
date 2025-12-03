namespace Day2;

public static class NumberExtensions
{
    public static long CountDigits(this long number)
    {
        var count = 0;
        if (number == 0) return 1;
        for (; number > 0; number /= 10)
        {
            count++;
        }
        return count;
    }
}