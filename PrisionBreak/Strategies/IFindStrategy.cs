namespace PrisionBreak.Strategies;


public interface IFindStrategy
{
    IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier);
}
