using PrisionBreak;

public static class Operators
{
    public static IEnumerable<bool> CheckPaths(this BoxContainer boxContainer)
    {
        for (var i = 1; i <= boxContainer.NonNull().Count; i++)
        {
            var path = boxContainer.FindPath(i);
            yield return path.Count <= boxContainer!.Limit;
        }
    }

    public static bool IsSuccess(this IEnumerable<bool> results) => results.Count(x => x) == 100;
}