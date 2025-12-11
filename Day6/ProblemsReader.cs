using System.Text.RegularExpressions;

namespace Day6;

public static partial class ProblemsReader
{
    public static IList<Problem> Read(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        var colCount = Whitespace().Split(lines[0].Trim()).Length;
        
        // Initialize array items
        var problems = new Problem[colCount];
        for (var col = 0; col < colCount; col++)
        {
            problems[col] = new Problem();
        }
        
        var operandCount = lines.Length - 1;
        foreach (var line in lines.Take(operandCount))
        {
            var words = Whitespace().Split(line.Trim());
            for (var col = 0; col < colCount; col++)
                problems[col].Numbers.Add(long.Parse(words[col]));
        }
        
        var lastWords = Whitespace().Split(lines.Last().Trim());
        for (var col = 0; col < colCount; col++)
            problems[col].Op = lastWords[col] == "*" ? Operator.Multiply : Operator.Add;

        return problems;
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex Whitespace();
}