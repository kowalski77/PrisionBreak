﻿namespace PrisionBreak.Strategies;

public class OwnBoxStrategy : BaseStrategy
{
    protected override IEnumerable<Box> FindLoop(IEnumerable<Box> boxCollection, int targetIdentifier)
    {
        var box = boxCollection.NonNull().First(x => x.Identifier == targetIdentifier);
        yield return box;

        while (box.Number != targetIdentifier)
        {
            box = boxCollection.First(x => x.Identifier == box.Number);
            yield return box;
        }
    }
}