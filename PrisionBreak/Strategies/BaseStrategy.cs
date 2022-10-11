namespace PrisionBreak.Strategies;

public abstract class BaseStrategy<T> : IFindStrategy<T>
{
    public abstract Func<IEnumerable<T>, int, IPathFinder<T>> PathFinderFactory { get; }
}
