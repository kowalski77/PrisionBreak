namespace PrisionBreak.Strategies;

public sealed class RandomBoxPathFinder : IPathFinder<Box>
{
    private readonly IEnumerable<Box> collection;
    private readonly int targetIdentifier;

    public RandomBoxPathFinder(IEnumerable<Box> collection, int targetIdentifier)
    {
        this.collection = collection;
        this.targetIdentifier = targetIdentifier;
    }

    public IEnumerable<Box> FindPath()
    {
        Dictionary<int, Box> dictionary = this.collection.ToDictionary(x => x.Identifier);
        IOrderedEnumerable<int> identifiers = dictionary.Keys.OrderBy(x => Random.Shared.Next());

        foreach (var identifier in identifiers)
        {
            Box box = dictionary[identifier];
            yield return box;

            if (box.Number == this.targetIdentifier)
            {
                yield break;
            }
        }
    }
}
