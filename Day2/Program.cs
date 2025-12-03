using Day2;

var ranges = RangeReader.Read("Input.txt").ToArray();
var invalidIds = ranges.GetInvalidIds().ToArray();
var sumInvalidIds = invalidIds.Sum();
return;