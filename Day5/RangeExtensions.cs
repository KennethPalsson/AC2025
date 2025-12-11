namespace Day5;

public static class RangeExtensions
{
    extension(IEnumerable<Range> ranges)
    {
        public long Count() => ranges.Sum(range => range.Last - range.First + 1);

        public IList<Range> GetNonOverlapping()
        {
            var sortedRanges = ranges.OrderBy(r => r.First).ToList();
            var result = new Queue<Range>();
            result.Enqueue(sortedRanges.First());
            foreach (var range in sortedRanges.Skip(1))
            {
                var lastRange = result.Last();
            
                // Merge ranges if they are overlapping
                if (range.First <= lastRange.Last)
                {
                    if (range.Last > lastRange.Last)
                        lastRange.Last = range.Last;
                }
                else
                {
                    result.Enqueue(range);
                }
            }

            return result.ToList();
        }
    }
}