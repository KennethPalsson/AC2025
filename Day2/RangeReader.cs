namespace Day2;

public static class RangeReader
{
    public static IEnumerable<(long, long)> Read(string filePath)
    {
        var line = File.ReadAllText(filePath);
        var items = line.Split(',');
        var groups = items.Select(item => item.Split('-'));
        var ranges = groups.Select(g => (long.Parse(g[0]), long.Parse(g[1])));
        return ranges;
    }
}