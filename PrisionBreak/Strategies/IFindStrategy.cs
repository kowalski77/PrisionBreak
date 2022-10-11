namespace PrisionBreak.Strategies;

public interface IFindStrategy<T>
{
    Func<IEnumerable<T>, int, IPathFinder<T>> PathFinderFactory { get; }
}
