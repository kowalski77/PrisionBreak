namespace PrisionBreak.Strategies;

public static class HashSetHelpers
{
    public static Box GetValue(this HashSet<Box> hashSet, int targetIdentifier) =>
        hashSet.NonNull().TryGetValue(new Box(targetIdentifier, 0), out var actualValue) ? 
        actualValue :
            throw new InvalidOperationException("Could not get the box from the hashSet");
}