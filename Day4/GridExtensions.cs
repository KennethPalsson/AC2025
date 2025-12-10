namespace Day4;

public static class GridExtensions
{
    extension(int[,] grid)
    {
        public int CountAccessibleRolls()
        {
            var result = 0;
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
            {
                if (grid[i, j] > 0 && grid.GetNeighborCount(i, j) < 4)
                    result++;
            }

            return result;
        }

        public int CountRolls()
        {
            var result = 0;
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
            {
                result += grid[i, j];
            }

            return result;
        }
        
        public int[,] RemoveNeighbors()
        {
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            var result = grid.CopyGrid();
            for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
            {
                if (grid[i, j] > 0 && grid.GetNeighborCount(i, j) < 4)
                {
                    result[i, j] = 0;
                }
            }

            return result;
        }
        
        private int[,] CopyGrid()
        {
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            var result = new int[rows, cols];
            for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
            {
                result[i, j] = grid[i, j];
            }

            return result;
        }

        private int GetNeighborCount(int row, int col)
        {
            var result = 0;
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            
            if (row > 0 && col > 0)
                result += grid[row - 1, col - 1];

            if (row > 0)
                result += grid[row - 1, col];

            if (row > 0 && col < cols - 1)
                result += grid[row - 1, col + 1];
            
            if (col > 0)
                result += grid[row, col - 1];
            
            if (col < cols - 1)
                result += grid[row, col + 1];
            
            if (row < rows - 1 && col > 0)
                result += grid[row + 1, col - 1];
            
            if (row < rows - 1)
                result += grid[row + 1, col];
            
            if (row < rows - 1 && col < cols - 1)
                result += grid[row + 1, col + 1];
            
            return result;
        }
    }
}