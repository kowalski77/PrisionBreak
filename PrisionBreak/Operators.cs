namespace PrisionBreak;

public static class Operators
{
    public static IScrumbled<Box> ToScrumbled(this IEnumerable<int> sequence) =>
        new BoxContainer(sequence.Select(x => new Box(x, x)), new RandomBoxStrategy());

    public static IScrumbled<Box> ToScrumbledWithOwnBoxStrategy(this IEnumerable<int> sequence) =>
        new BoxContainer(sequence.Select(x => new Box(x, x)), new OwnBoxStrategy());

    public static bool IsScenarioSuccess(this IScrumbled<Box> scrumbled, int limit) => 
        scrumbled.CheckPaths(limit.NonNegativeOrZero()).All(x => x);

    private static IEnumerable<bool> CheckPaths(this IScrumbled<Box> scrumbled, int limit)
    {
        for (var i = 1; i <= scrumbled.NonNull().Count; i++)
        {
            yield return scrumbled.GetPath(i).Count <= limit;
        }
    }
}