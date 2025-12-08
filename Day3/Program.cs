using Day3;

var banks = BankReader.Read("Input.txt").ToArray();
var maxJoltage1 = banks.Sum(b => b.GetMaxJoltage1());
Console.WriteLine(maxJoltage1);

var maxJoltage2 = banks.Sum(b => b.GetMaxJoltage2());
Console.WriteLine(maxJoltage2);