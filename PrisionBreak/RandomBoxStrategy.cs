namespace PrisionBreak;

public class RandomBoxStrategy : IFindStrategy
{
    public IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier)
    {
        return FindLoop(boxCollection, identifier).ToList();
    }

    private static IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var random = new Random();
        var identifiers = boxCollection.Select(x => x.Identifier).OrderBy(x => random.Next());

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
