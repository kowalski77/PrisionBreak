namespace PrisionBreak;

public class RandomBoxStrategy : IFindStrategy
{
    public IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier)
    {
        return FindLoop(boxCollection, identifier).ToList();
    }

    private static IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, int targetIdentifier)
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
