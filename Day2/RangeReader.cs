namespace Day2;

public static class RangeReader
{
    public static IEnumerable<(string, string)> Read(string filePath)
    {
        var line = File.ReadAllText(filePath);
        var items = line.Split(',');
        var groups = items.Select(item => item.Split('-'));
        var ranges = groups.Select(g => (g[0], g[1]));
        return ranges;
    }
}