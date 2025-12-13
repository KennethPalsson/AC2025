namespace Day6;

public static class LinesExtensions
{
    extension(string[] lines)
    {
        public IEnumerable<char[,]> GetProblemGrids()
        {
            var rowCount = lines.Length;
            var colCount = lines[0].Length;
            var ends = lines.GetEnds(colCount);

            var start = 0;
            while (ends.TryDequeue(out var end))
            {
                var problemGrid = lines.CreateProblemGrid(start, end, rowCount);
                yield return problemGrid;
                start = end + 1;
            }
        }

        private Queue<int> GetEnds(int colCount)
        {
            var ends = new Queue<int>();
            for (var col = 0; col < colCount; col++)
            {
                if (lines.EmptyColumn(col))
                    ends.Enqueue(col);
            }
            ends.Enqueue(colCount);
            return ends;
        }

        private bool EmptyColumn(int col) => lines.All(line => line[col] == ' ');

        private char[,] CreateProblemGrid(int start, int end, int rowCount)
        {
            var problemGrid = new char[rowCount, end - start];
            for (var row = 0; row < rowCount; row++)
            for (var i = 0; i < end - start; i++)
                problemGrid[row, i] = lines[row][start + i];
            return problemGrid;
        }
    }
}