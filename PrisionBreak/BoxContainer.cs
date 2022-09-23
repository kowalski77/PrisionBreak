using System.Collections;

namespace PrisionBreak;

public class BoxContainer : IReadOnlyList<Box>
{
    private readonly int[] numbers;

    public BoxContainer(int total, int limit)
    {
        this.numbers = Enumerable.Range(1, total.NonNegativeOrZero()).ToArray();
        this.Items = new List<Box>(total);
        this.Limit = limit.NonNegativeOrZero();
        this.Scramble();
    }

    private List<Box> Items { get; }

    public int Count => this.Items.Count;

    public Box this[int index] => this.Items[index];

    public int Limit { get; }

    public IReadOnlyList<Box> FindPath(int identifier)
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

    public IEnumerator<Box> GetEnumerator() => this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void Scramble()
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
}

public record Box(int Identifier, int Number);
