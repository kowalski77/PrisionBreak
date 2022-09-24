namespace PrisionBreak;

public class OwnBoxStrategy : IFindStrategy
{
    public IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier)
    {
        var box = boxCollection.FirstOrDefault(x => x.Identifier == identifier.NonNegativeOrZero()) ??
            throw new ArgumentException("Identifier not found", nameof(identifier));

        return FindLoop(boxCollection, box, identifier).ToList();
    }

    private static IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, Box box, int identifier)
    {
        yield return box;

        while (box.Number != identifier)
        {
            box = boxCollection.First(x => x.Identifier == box.Number);
            yield return box;
        }
    }
}
