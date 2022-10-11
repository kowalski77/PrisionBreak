namespace PrisionBreak.Strategies;

public class RandomBoxStrategy : BaseStrategy<Box>
{
    protected override IEnumerable<Box> FindPathConcrete(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var dictionary = boxCollection.ToDictionary(x => x.Identifier);
        var identifiers = dictionary.Keys.OrderBy(x=> Random.Shared.Next());

        foreach (var identifier in identifiers)
        {
            var box = dictionary[identifier];
            yield return box;

            if (box.Number == targetIdentifier)
            {
                yield break;
            }
        }
    }
}
