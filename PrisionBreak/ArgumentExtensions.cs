using System.Runtime.CompilerServices;

namespace PrisionBreak;

public static class ArgumentExtensions
{
    public static int NonNegativeOrZero(this int value, [CallerArgumentExpression("value")] string? paramName = null) =>
        value > 0 ? value : 
        throw new ArgumentException(paramName);
}
