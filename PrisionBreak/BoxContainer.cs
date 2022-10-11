using System.Collections;
using PrisionBreak.Strategies;

namespace PrisionBreak;

public class BoxContainer : IScrumbled<Box>
{
    private readonly IFindStrategy<Box> findStategy;

    public BoxContainer(IEnumerable<Box> sequence, IFindStrategy<Box> findStategy)
    {
        this.Items = sequence.NonNull().ToArray();
        this.findStategy = findStategy.NonNull();
    }

    private Box[] Items { get; }

    public int Count => this.Items.Length;

    public IEnumerator<Box> GetEnumerator() => this.Items.AsEnumerable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IScrumbled<Box> Scrumble() => 
        new BoxContainer(CreateBoxes(this.Items.Select(x => x.Number).OrderBy(x => Random.Shared.Next())), this.findStategy);

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
