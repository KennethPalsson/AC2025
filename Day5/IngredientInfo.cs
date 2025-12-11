namespace Day5;

public record IngredientInfo(IList<Range> IdRanges, IList<long> Ids)
{
    public int CountFreshIngredients() =>
        Ids.Count(id => IdRanges.Any(idRange => id >= idRange.First && id <= idRange.Last));
}