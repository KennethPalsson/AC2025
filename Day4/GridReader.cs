namespace Day4;

public static class GridReader
{
    public static int[,] ReadGrid(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        var rows = lines.Length;
        var cols = lines[0].Length;
        var grid = new int[rows, cols];
        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
        {
            if (lines[i][j] == '@')
                grid[i, j] = 1;
        }
        return grid;
    }
}