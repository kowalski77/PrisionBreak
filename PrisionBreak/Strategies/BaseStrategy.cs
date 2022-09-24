namespace PrisionBreak.Strategies;

public abstract class BaseStrategy : IFindStrategy
{
    public IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier) => 
        this.FindLoop(boxCollection.NonNull(), identifier.NonNegativeOrZero())
        .ToList();

    protected abstract IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, int targetIdentifier);
}
