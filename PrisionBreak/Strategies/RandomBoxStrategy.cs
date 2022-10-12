namespace PrisionBreak.Strategies;

public class RandomBoxStrategy : IFindStrategy<Box>
{
    public Func<IEnumerable<Box>, int, IPathFinder<Box>> PathFinderFactory =>
        (boxCollection, target) => new RandomBoxPathFinder(boxCollection, target);
}
