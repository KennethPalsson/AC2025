using System.Text;

namespace Day6;

public static class ProblemGridExtensions
{
    extension(char[,] problemGrid)
    {
        public string ToText()
        {
            var sb = new StringBuilder();
            var rowCount = problemGrid.GetLength(0);
            for (var i = 0; i < rowCount; i++)
            {
                var line = new StringBuilder();
                var colCount = problemGrid.GetLength(1);
                for (var j = 0; j < colCount; j++)
                    line.Append(problemGrid[i, j]);
                sb.AppendLine(line.ToString());
            }
            return sb.ToString();
        }

        public Problem GetProblem()
        {
            return new Problem
            {
                Numbers = GetNumbers(problemGrid).ToList(),
                Op = GetOperator(problemGrid)
            };
        }

        private IEnumerable<long> GetNumbers()
        {
            var rowCount = problemGrid.GetLength(0);
            var colCount = problemGrid.GetLength(1);
            for (var col = 0; col < colCount; col++)
            {
                var number = 0L;
                var exp = 0;
                for (var row = rowCount - 2; row >= 0; row--)
                {
                    var c = problemGrid[row, col];
                    if (c != ' ')
                    {
                        var value = (long)((c - '0') * Math.Pow(10, exp));
                        number += value;
                        exp++;
                    }
                }
                yield return number;
            }
        }

        private Operator GetOperator()
        {
            var rowCount = problemGrid.GetLength(0);
            var c = problemGrid[rowCount - 1, 0];
            return c == '*' ? Operator.Multiply : Operator.Add;
        }
    }
}