namespace PrisionBreak;


public interface IFindStrategy
{
    IReadOnlyList<Box> FindPath(IEnumerable<Box> boxCollection, int identifier);
}
