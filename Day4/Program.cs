using Day4;

var grid = GridReader.ReadGrid("Input.txt");
var accessibleRollCount = grid.CountAccessibleRolls();
Console.WriteLine(accessibleRollCount);

var rollCount0 = grid.CountRolls();
var rollCount = rollCount0;
var newGrid = new int[,] { };
int? newRollCount = null;
do
{
    if (newRollCount.HasValue)
    {
        grid = newGrid;
        rollCount = newRollCount.Value;
    }
    newGrid = grid.RemoveNeighbors();
    newRollCount = newGrid.CountRolls();
} while (newRollCount != rollCount);
Console.WriteLine(rollCount0 - rollCount);