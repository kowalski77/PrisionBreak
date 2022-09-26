namespace PrisionBreak.Strategies;

public class OwnBoxStrategy : BaseStrategy<Box>
{
    protected override IEnumerable<Box> FindPathConcrete(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var dictionary = boxCollection.ToDictionary(x => x.Identifier);

        var box = dictionary[targetIdentifier];

        yield return box;

        while (box.Number != targetIdentifier)
        {
            box = dictionary[box.Number];
            yield return box;
        }
    }
}
