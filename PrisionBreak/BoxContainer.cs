using System.Collections;
using PrisionBreak.Strategies;

namespace PrisionBreak;

public class BoxContainer : IScrumbled<Box>
{
    private readonly IFindStrategy<Box> findStategy;

    public BoxContainer(IEnumerable<Box> sequence, IFindStrategy<Box> findStategy)
    {
        this.Items = new List<Box>(sequence.NonNull());
        this.findStategy = findStategy.NonNull();
    }

    private List<Box> Items { get; }
    
    public int Count => this.Items.Count;

    public Box this[int index] => this.Items[index];

    public IEnumerator<Box> GetEnumerator() => this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IScrumbled<Box> Scrumble() => 
        new BoxContainer(CreateBoxes(this.Items.Select(x => x.Number).OrderBy(x => new Random().Next())), this.findStategy);

    public IReadOnlyList<Box> GetPath(int identifier) => 
        this.findStategy.FindPath(this.Items, identifier.NonNegativeOrZero());

    private static IEnumerable<Box> CreateBoxes(IEnumerable<int> numbers)
    {
        var boxNumber = 1;
        foreach (var item in numbers)
        {
            yield return new Box(boxNumber++, item);
        }
    }
}
