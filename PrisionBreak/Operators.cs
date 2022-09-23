using PrisionBreak;

public static class Operators
{
    public static BoxContainer ToBoxContainer(this IEnumerable<int> sequence) => new(sequence);

    // To BoxContainer
    public static IEnumerable<bool> CheckPaths(this BoxContainer boxContainer)
    {
        for (var i = 1; i <= boxContainer.NonNull().Count; i++)
        {
            var path = boxContainer.FindPath(i);
            yield return path.Count <= boxContainer!.Limit;
        }
    }

    // To BoxContainer
    public static bool IsSuccess(this IEnumerable<bool> results) => results.Count(x => x) == 100;
}