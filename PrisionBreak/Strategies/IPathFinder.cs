namespace PrisionBreak.Strategies;

public interface IPathFinder<out T>
{
    IEnumerable<T> FindPath();
}
