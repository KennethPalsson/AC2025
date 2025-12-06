using Day2;

var ranges = RangeReader.Read("Input.txt").ToArray();

var integerRanges = ranges
    .Select(p => (long.Parse(p.Item1), long.Parse(p.Item2)))
    .ToArray();
var invalidIds1 = integerRanges.GetInvalidIds1().ToArray();
var sumInvalidIds1 = invalidIds1.Sum();
Console.WriteLine(sumInvalidIds1);

var sumInvalidIds2 = ranges.GetInvalidIds2().Select(long.Parse).Distinct().Sum();
Console.WriteLine(sumInvalidIds2);
