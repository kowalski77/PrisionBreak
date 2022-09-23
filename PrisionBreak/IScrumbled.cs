namespace PrisionBreak;

public interface IScrumbled<out T> : IReadOnlyList<T>
{
    IScrumbled<T> Scrumble();

    IReadOnlyList<T> GetPath(int identifier);

    bool ScenarioSuccess();
}
