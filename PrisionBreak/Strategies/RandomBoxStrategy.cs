namespace PrisionBreak.Strategies;

public class RandomBoxStrategy : BaseStrategy<Box>
{
    protected override IEnumerable<Box> FindPathConcrete(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var hashSet = boxCollection.ToHashSet(new BoxIdentifierEqualityComparer());
        
        var identifiers = boxCollection.Select(x => x.Identifier).OrderBy(x => new Random().Next());

        foreach (var identifier in identifiers)
        {
            var box = hashSet.GetValue(identifier);
            yield return box;

            if (box.Number == targetIdentifier)
            {
                yield break;
            }
        }
    }
}
