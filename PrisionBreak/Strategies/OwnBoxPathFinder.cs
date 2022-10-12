namespace PrisionBreak.Strategies;

public sealed class OwnBoxPathFinder : IPathFinder<Box>
{
    private readonly Dictionary<int, Box> dictionary;
    private readonly int targetIdentifier;

    public OwnBoxPathFinder(IEnumerable<Box> collection, int targetIdentifier)
    {
        this.dictionary = collection.ToDictionary(x => x.Identifier);
        this.targetIdentifier = targetIdentifier;
    }

    public IEnumerable<Box> FindPath()
    {
        Box box = dictionary[this.targetIdentifier];

        yield return box;

        while (box.Number != this.targetIdentifier)
        {
            box = dictionary[box.Number];
            yield return box;
        }
    }
}
