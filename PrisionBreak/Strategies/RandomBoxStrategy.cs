namespace PrisionBreak.Strategies;

public class RandomBoxStrategy : BaseStrategy<Box>
{
    public override Func<IEnumerable<Box>, int, IPathFinder<Box>> PathFinderFactory =>
        (boxCollection, target) => new RandomBoxPathFinder(boxCollection, target);
}
