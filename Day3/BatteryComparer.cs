namespace Day3;

public class BatteryComparer : IComparer<(int Index, int Item)>
{
    public int Compare((int Index, int Item) x, (int Index, int Item) y)
    {
        var itemComparison = x.Item.CompareTo(y.Item);
        if (itemComparison != 0) return itemComparison;
        return -x.Index.CompareTo(y.Index);
    }
}