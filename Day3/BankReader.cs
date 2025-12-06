namespace Day3;

public static class BankReader
{
    public static IEnumerable<int[]> Read(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        return lines.Select(l => l.Select(c => c - '0').ToArray());
    }
}