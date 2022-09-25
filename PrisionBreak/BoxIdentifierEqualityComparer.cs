using System.Diagnostics.CodeAnalysis;

namespace PrisionBreak;

public class BoxIdentifierEqualityComparer : IEqualityComparer<Box>
{
    public bool Equals(Box x, Box y) => x.Identifier.Equals(y.Identifier);

    public int GetHashCode([DisallowNull] Box obj) => obj.Identifier.GetHashCode();
}
