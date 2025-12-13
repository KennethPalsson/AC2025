using Day6;

var problems1 = ProblemsReader.Read("Input.txt");

var total1 = problems1.Sum(problem => problem.GetResult());
Console.WriteLine(total1);

var grids = ProblemGridsReader.Read("Input.txt");
var problems2 = grids.Select(g => g.GetProblem()).ToList();
var total2 = problems2.Sum(problem => problem.GetResult());
Console.WriteLine(total2);
