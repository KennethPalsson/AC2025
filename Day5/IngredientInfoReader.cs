namespace Day5;

public static class IngredientInfoReader
{
    public static IngredientInfo Read(string fileName)
    {
        var idRanges = new List<Range>();
        var ids = new List<long>();
        var lines = File.ReadLines(fileName).ToArray();
        var rangeLines = lines.TakeWhile(line => !string.IsNullOrWhiteSpace(line));
        foreach (var line in rangeLines)
        {
            var array = line.Split('-');
            var idRange = new Range(long.Parse(array[0]), long.Parse(array[1]));
            idRanges.Add(idRange);
        }

        var idLines = lines.SkipWhile(line => !string.IsNullOrWhiteSpace(line)).Skip(1).ToArray();
        foreach (var line in idLines)
        {
            var id = long.Parse(line);
            ids.Add(id);
        }
        
        return new IngredientInfo(idRanges, ids);
    }
}