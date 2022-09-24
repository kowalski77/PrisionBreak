namespace PrisionBreak.Strategies;

public abstract class BaseStrategy<T> : IFindStrategy<T>
{
    public IReadOnlyList<T> FindPath(IEnumerable<T> collection, int identifier) => 
        this.FindPathConcrete(collection.NonNull(), identifier.NonNegativeOrZero())
        .ToList();

    protected abstract IEnumerable<T> FindPathConcrete(IEnumerable<T> boxCollection, int targetIdentifier);
}
