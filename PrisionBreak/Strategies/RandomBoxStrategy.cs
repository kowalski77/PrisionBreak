namespace PrisionBreak.Strategies;

public class RandomBoxStrategy : BaseStrategy<Box>
{
    protected override IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var identifiers = boxCollection.Select(x => x.Identifier).OrderBy(x => new Random().Next());

        foreach (var identifier in identifiers)
        {
            var box = boxCollection.First(x => x.Identifier == identifier);
            yield return box;

            if (box.Number == targetIdentifier)
            {
                yield break;
            }
        }
    }
}
