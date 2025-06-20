namespace BigNumbers.ArithmeticOperations;

public abstract class ColumnOperationAbstractStrategy
{
    protected readonly Func<byte, byte, byte, (byte result, byte carry)> Addition = 
        (firstDigit, secondDigit, carry) =>
    {
        var sum = firstDigit + secondDigit + carry;
        var result = sum % 10;
        var newCarry = sum / 10;

        return ((byte) result, (byte) newCarry);
    };

    protected readonly Func<byte, byte, byte, (byte result, byte carry)> Subtraction =
        (firstDigit, secondDigit, carry) =>
    {
        var result = firstDigit - secondDigit - carry;
        var newCarry = 0;

        if (result < 0)
        {
            result += 10;
            newCarry = 1;
        }

        return ((byte) result, (byte) newCarry);
    };
    
    protected IList<byte> ProcessColumnDigits(IList<byte> firstNumberDigits, IList<byte> secondNumberDigits,  Func<byte, byte, byte, (byte result, byte carry)> arithmeticOperation)
    {
        var result = new List<byte>();
        var firstNumberIndex = firstNumberDigits.Count;
        var secondNumberIndex = secondNumberDigits.Count;
        byte carry = 0;
        
        while (firstNumberIndex > 0 || secondNumberIndex > 0 || carry > 0)
        {
            var firstDigit = GetDigitOrZero(firstNumberDigits, firstNumberIndex);
            var secondDigit = GetDigitOrZero(secondNumberDigits, secondNumberIndex);
            
            var (arithmeticOperationResult, newCarry) = arithmeticOperation(firstDigit, secondDigit, carry);
            carry = newCarry;
            result.Add(arithmeticOperationResult);
            
            firstNumberIndex--;
            secondNumberIndex--;
        }

        return result;
    }

    private byte GetDigitOrZero(IList<byte> digits, int index)
    {
        return index > 0 ? digits[index - 1] : (byte) 0;
    }
}