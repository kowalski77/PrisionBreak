namespace PrisionBreak;

public static class Operators
{
    public static BoxContainer ToBoxContainer(this IEnumerable<int> sequence) => new(sequence.Select(x=> new Box(x, x)));
}