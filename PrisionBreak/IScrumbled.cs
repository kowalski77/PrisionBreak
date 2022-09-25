namespace PrisionBreak;

public interface IScrumbled<out T> : IEnumerable<T>
{
    int Count { get; }

    IScrumbled<T> Scrumble();

    IReadOnlyList<T> GetPath(int identifier);
}
