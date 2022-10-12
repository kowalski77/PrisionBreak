namespace PrisionBreak.Strategies;

public sealed class RandomBoxPathFinder : IPathFinder<Box>
{
    private readonly Dictionary<int, Box> dictionary;
    private readonly int targetIdentifier;

    public RandomBoxPathFinder(IEnumerable<Box> collection, int targetIdentifier)
    {
        this.dictionary = collection.ToDictionary(x => x.Identifier);
        this.targetIdentifier = targetIdentifier;
    }

    public IEnumerable<Box> FindPath()
    {
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
