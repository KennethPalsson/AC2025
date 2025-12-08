namespace Day3;

public static class BankExtensions
{
    extension(int[] bank)
    {
        public int GetMaxJoltage1()
        {
            var battery1 = bank.Take(bank.Length - 1).Index().MaxBy(b => b.Item);
            var joltage0 = bank.Skip(battery1.Index + 1).Max();
            return battery1.Item * 10 + joltage0;
        }

        public long GetMaxJoltage2()
        {
            IComparer<(int Index, int Item)> comparer = new BatteryComparer();

            var batteries = bank.Index().ToArray();
            List<(int Index, int Item)> maxBatteries = [];
            var start = 0;
            var end = bank.Length - 11;
            for (var i = 0; i < 12; i++)
            {
                var battery = batteries.GetMax(start, end - start, comparer);
                maxBatteries.Add(battery);
                start = battery.Index + 1;
                end++;
            }
        
            var joltage = maxBatteries.GetJoltage();
            return joltage;
        }
    }

    extension(IEnumerable<(int Index, int Item)> batteries)
    {
        private (int Index, int Item) GetMax(int start, int length,
            IComparer<(int Index, int Item)> comparer)
        {
            var array = batteries.ToArray();
            ArgumentOutOfRangeException.ThrowIfZero(array.Length, nameof(array.Length));
            var max = array[start];
            for (var i = start + 1; i < start + length; i++)
            {
                if (comparer.Compare(array[i], max) > 0)
                    max = array[i];
            }

            return max;
        }

        private long GetJoltage()
        {
            var result = 0L;
            var exponent = 11;
            foreach (var battery in batteries)
            {
                var pow10 = (long)Math.Pow(10, exponent);
                result += battery.Item * pow10;
                exponent--;
            }

            return result;
        }
    }
}