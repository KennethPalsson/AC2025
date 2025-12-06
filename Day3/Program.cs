using Day3;

var banks = BankReader.Read("Input.txt").ToArray();
var maxVoltage = banks.Sum(b => b.GetMaxJoltage());
Console.WriteLine(maxVoltage);