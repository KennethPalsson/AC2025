namespace Day6;

public class Problem
{
    public IList<long> Numbers { get; init; } = [];
    public Operator Op { get; set; }
    
    public long GetResult() => Op == Operator.Multiply 
        ? Numbers.Aggregate(1L, (product, number) => product * number) 
        : Numbers.Sum();

    public override string ToString()
    {
        return string.Join($" {(Op == Operator.Multiply ? '*' : '+')} ", Numbers) + " = " + GetResult();
    }
}