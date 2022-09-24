namespace PrisionBreak;

public class OwnBoxStrategy : IFindStrategy
{
    public IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier) =>
        FindLoop(boxCollection.NonNull(), identifier.NonNegativeOrZero()).ToList();

    private static IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var box = boxCollection.NonNull().First(x => x.Identifier == targetIdentifier);
        yield return box;

        while (box.Number != targetIdentifier)
        {
            box = boxCollection.First(x => x.Identifier == box.Number);
            yield return box;
        }
    }
}
