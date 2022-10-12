namespace PrisionBreak.Strategies;

public class OwnBoxStrategy : IFindStrategy<Box>
{
    public Func<IEnumerable<Box>, int, IPathFinder<Box>> PathFinderFactory => 
        (boxCollection, target) => new OwnBoxPathFinder(boxCollection, target);
}
