namespace PrisionBreak;

public static class FindStrategy
{
    public static IFindStrategy Own => new OwnBoxStrategy();

    public static IFindStrategy Random => new RandomBoxStrategy();
}
