namespace PrisionBreak;

public static class Operators
{
    public static IScrumbled<Box> ToScrumbled(this IEnumerable<int> sequence) => 
        new BoxContainer(sequence.Select(x=> new Box(x, x)));
}