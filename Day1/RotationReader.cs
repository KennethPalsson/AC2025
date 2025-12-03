namespace Day1;

public static class RotationReader
{
    public static int[] Read(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines
            .Select(l => l[0] == 'L' ? -int.Parse(l[1..]) : int.Parse(l[1..]))
            .ToArray();
    }
}