using System.Text.RegularExpressions;
using BigNumbers.Exceptions;

namespace BigNumbers.Extensions;

public static class StringExtensions
{
    public static BigNumber ToBigNumber(this string value)
    {
        var onlyDigitsInString = new Regex(@"^\d+$");

        if (onlyDigitsInString.IsMatch(value))
        {
            var digits =  value.Select(c => byte.Parse(c.ToString())).ToList();
            return new BigNumber(digits);
        }
        
        throw new UnsupportedStringFormat($"The string format is not supported. Value should contains only digits. Current value: {value}");
    }
}