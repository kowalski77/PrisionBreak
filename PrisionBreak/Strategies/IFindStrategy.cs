namespace PrisionBreak.Strategies;

public interface IFindStrategy<T>
{
    IReadOnlyList<T> FindPath(IEnumerable<T> collection, int identifier);
}
