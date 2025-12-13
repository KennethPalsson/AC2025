namespace Day6;

public static class ProblemGridsReader
{
    public static IEnumerable<char[,]> Read(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        foreach (var grid in lines.GetProblemGrids())
            yield return grid;
    }
}