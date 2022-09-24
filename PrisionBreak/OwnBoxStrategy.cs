namespace PrisionBreak;

public class OwnBoxStrategy : IFindStrategy
{
    public IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier)
    {
        var box = boxCollection.First(x => x.Identifier == identifier.NonNegativeOrZero());

        return FindLoop(boxCollection, box, identifier).ToList();
    }

    private static IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, Box box, int targetIdentifier)
    {
        yield return box;

        while (box.Number != targetIdentifier)
        {
            box = boxCollection.First(x => x.Identifier == box.Number);
            yield return box;
        }
    }
}
