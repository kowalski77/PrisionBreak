using System.Collections;

namespace PrisionBreak;

public class BoxContainer : IReadOnlyList<Box>
{
    private readonly int[] numbers;

    public BoxContainer(int total)
    {
        this.numbers = Enumerable.Range(1, total).ToArray();
        this.Items = new List<Box>(total);
    }

    private List<Box> Items { get; }

    public int Count => this.Items.Count;

    public Box this[int index] => this.Items[index];

    public void Scramble()
    {
        var random = new Random();
        var scrambled = this.numbers.OrderBy(x => random.Next()).ToArray();
        var boxNumber = 1;
        for (var i = 0; i < scrambled.Length; i++)
        {
            var box = new Box(boxNumber, scrambled[i]);
            this.Items.Add(box);
            boxNumber++;
        }
    }

    public IReadOnlyList<Box> FindPath(int identifier)
    {
        var path = new List<Box>();

        var box = this.Items.FirstOrDefault(x => x.Identifier == identifier) ?? 
            throw new ArgumentException("Identifier not found, Scramble the boxes first", nameof(identifier));
        
        path.Add(box);
        
        while (box.Number != identifier)
        {
            box = this.Items.First(x => x.Identifier == box.Number);
            path.Add(box);
        }

        return path;
    }

    public IEnumerator<Box> GetEnumerator() => this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public record Box(int Identifier, int Number);
