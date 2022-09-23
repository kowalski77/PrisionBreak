using System.Collections;

namespace PrisionBreak;

public class BoxContainer : IScrumbled<Box>
{
    public BoxContainer(IEnumerable<Box> sequence)
    {
        ArgumentNullException.ThrowIfNull(sequence);
        this.Items = new List<Box>(sequence);
    }

    private List<Box> Items { get; }

    public int Limit => Items.Count / 2;

    public int Count => this.Items.Count;

    public Box this[int index] => this.Items[index];
    
    public IScrumbled<Box> Scrumble()
    {
        var random = new Random();
        var numbers = this.Items.Select(x => x.Number);
        var scrambled = GetBoxes(numbers.OrderBy(x => random.Next()));

        return new BoxContainer(scrambled);
    }

    public IReadOnlyList<Box> GetPath(int identifier)
    {
        var path = new List<Box>();

        var box = this.Items.FirstOrDefault(x => x.Identifier == identifier.NonNegativeOrZero()) ??
            throw new ArgumentException("Identifier not found", nameof(identifier));

        path.Add(box);

        while (box.Number != identifier)
        {
            box = this.Items.First(x => x.Identifier == box.Number);
            path.Add(box);
        }

        return path;
    }

    public bool IsSuccess() => this.CheckPaths().Count(x => x) == 100;

    private IEnumerable<bool> CheckPaths()
    {
        for (var i = 1; i <= this.Items.Count; i++)
        {
            var path = this.GetPath(i);
            yield return path.Count <= this.Limit;
        }
    }

    private static IEnumerable<Box> GetBoxes(IEnumerable<int> numbers)
    {
        var boxNumber = 1;
        foreach (var item in numbers)
        {
            yield return new Box(boxNumber++, item);
        }
    }


    public IEnumerator<Box> GetEnumerator() => this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
