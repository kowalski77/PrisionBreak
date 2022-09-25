namespace PrisionBreak.Strategies;

public class OwnBoxStrategy : BaseStrategy<Box>
{
    protected override IEnumerable<Box> FindPathConcrete(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var hashSet = boxCollection.ToHashSet(new BoxIdentifierEqualityComparer());
        var box = hashSet.GetValue(targetIdentifier);

        yield return box;

        while (box.Number != targetIdentifier)
        {
            box = hashSet.GetValue(box.Number);
            yield return box;
        }
    }
}
