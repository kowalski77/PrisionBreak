using PrisionBreak.Strategies;

namespace PrisionBreak;

public static class Operators
{
    public static IScrumbled<Box> ToScrumbled(this IEnumerable<int> sequence) =>
        new BoxContainer(sequence.Select(x => new Box(x, x)), new RandomBoxStrategy());

    public static IScrumbled<Box> ToScrumbledWithOwnBoxStrategy(this IEnumerable<int> sequence) =>
        new BoxContainer(sequence.Select(x => new Box(x, x)), new OwnBoxStrategy());

    public static IEnumerable<IReadOnlyList<Box>> RunAll(this IScrumbled<Box> scrumbled)
    {
        for (var i = 1; i <= scrumbled.NonNull().Count; i++)
        {
            yield return scrumbled.GetPath(i);
        }
    }

    public static bool Success(this IEnumerable<IReadOnlyList<Box>> results, int limit) => 
        results.All(x => x.Count <= limit);
}