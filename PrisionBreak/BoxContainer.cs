using System.Collections;

namespace PrisionBreak;

public class BoxContainer : IScrumbled<Box>
{
    private readonly IFindStrategy findStategy;

    public BoxContainer(IEnumerable<Box> sequence, IFindStrategy findStategy)
    {
        ArgumentNullException.ThrowIfNull(sequence);
        ArgumentNullException.ThrowIfNull(findStategy);
        
        this.Items = new List<Box>(sequence);
        this.findStategy = findStategy;
    }

    private List<Box> Items { get; }

    public int Limit => Items.Count / 2;

    public bool IsScenarioSuccess() => this.CheckPaths().Count(x => x) == this.Items.Count;

    public IEnumerator<Box> GetEnumerator() => this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IScrumbled<Box> Scrumble()
    {
        var random = new Random();
        var numbers = this.Items.Select(x => x.Number);
        var scrambled = CreateBoxes(numbers.OrderBy(x => random.Next()));

        return new BoxContainer(scrambled, this.findStategy);
    }

    public IReadOnlyList<Box> GetPath(int identifier)
    {
        return this.findStategy.FindPath(this.Items, identifier);
    }

    private IEnumerable<bool> CheckPaths()
    {
        for (var i = 1; i <= this.Items.Count; i++)
        {
            var path = this.GetPath(i);
            yield return path.Count <= this.Limit;
        }
    }

    private static IEnumerable<Box> CreateBoxes(IEnumerable<int> numbers)
    {
        var boxNumber = 1;
        foreach (var item in numbers)
        {
            yield return new Box(boxNumber++, item);
        }
    }
}
