namespace PrisionBreak;

public static class FindStrategy
{
    public static IFindStrategy Loop => new LoopBoxStrategy();

    public static IFindStrategy Random => new RandomBoxStrategy();
}
