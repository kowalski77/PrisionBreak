namespace PrisionBreak.Strategies;

public sealed class OwnBoxPathFinder : IPathFinder<Box>
{
    private readonly IEnumerable<Box> collection;
    private readonly int targetIdentifier;

    public OwnBoxPathFinder(IEnumerable<Box> collection, int targetIdentifier)
    {
        this.collection = collection;
        this.targetIdentifier = targetIdentifier;
    }

    public IEnumerable<Box> FindPath()
    {
        Dictionary<int, Box> dictionary = this.collection.ToDictionary(x => x.Identifier);

        Box box = dictionary[this.targetIdentifier];

        yield return box;

        while (box.Number != this.targetIdentifier)
        {
            box = dictionary[box.Number];
            yield return box;
        }
    }
}
