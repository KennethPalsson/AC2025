namespace Day3;

public static class BankExtensions
{
    public static int GetMaxJoltage(this int[] bank)
    {
        var battery1 = bank.Take(bank.Length - 1).Index().MaxBy(b => b.Item);
        var voltage0 = bank.Skip(battery1.Index + 1).Max();
        return battery1.Item * 10 + voltage0;
    }
}