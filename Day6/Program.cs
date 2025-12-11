using Day6;

var problems = ProblemsReader.Read("Input.txt");

var total = problems.Sum(problem => problem.GetResult());
Console.WriteLine(total);