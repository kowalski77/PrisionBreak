namespace PrisionBreak.Strategies;

public class OwnBoxStrategy : BaseStrategy<Box>
{
    public override Func<IEnumerable<Box>, int, IPathFinder<Box>> PathFinderFactory => 
        (boxCollection, target) => new OwnBoxPathFinder(boxCollection, target);
}
