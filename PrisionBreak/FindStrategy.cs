namespace PrisionBreak;

public static class FindStrategy
{
    public static IFindStrategy Own => new OwnBoxStrategy();
}
