using BigNumbers.Exceptions;

namespace BigNumbers.Extensions;

public static class ListExtensions
{
    private const byte Zero = 0;
    public static BigNumber ToBigNumber<T>(this IList<T> list) where T : struct
    {
        if (typeof(T) == typeof(byte))
        {
            return new BigNumber(list.Cast<byte>().ToList());
        }

        if (typeof(T) == typeof(short) || typeof(T) == typeof(int) || 
            typeof(T) == typeof(long) || typeof(T) == typeof(sbyte) ||
            typeof(T) == typeof(ushort) || typeof(T) == typeof(uint))
        {
            return new BigNumber(list.Select(x => Convert.ToByte(x)).ToList());
        }
        
        throw new TypeNotSupportedException($"Type {typeof(T)} is not supported for conversion to BigNumber.");
    }
    
    public static IList<byte> TrimRedundantZeros(this IList<byte> digits)
    {
        if (digits.All(d => d == 0))
        {
            return new List<byte> { Zero };
        }

        return digits;
    }
}