namespace PrisionBreak;

public interface IScrumbled<out T> : IEnumerable<T>
{
    IScrumbled<T> Scrumble();

    IReadOnlyList<T> GetPath(int identifier);

    bool IsScenarioSuccess();
}
