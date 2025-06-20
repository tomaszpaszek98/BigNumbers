using BigNumbers.ArithmeticOperations;
using BigNumbers.Extensions;

public class ColumnMultiplicationStrategy : ColumnOperationAbstractStrategy, IColumnOperation
{
    private const byte Zero = 0;
    
    public IList<byte> Count(IList<byte> firstNumber, IList<byte> secondNumber)
    {
        var finalResult = new List<byte>();
        var depth = 0;

        for (var i = firstNumber.Count; i > 0; i--)
        {
            var currentRowResult = new List<byte>();
            byte carry = 0;
            
            for (var j = secondNumber.Count; j > 0; j--)
            {
                var (resultDigit, newCarry) = MultiplyDigits(firstNumber[i - 1], secondNumber[j - 1], carry);
                carry = newCarry;
                currentRowResult.Add(resultDigit);
            }

            AddCarryIfNeeded(currentRowResult, carry);
            SortPartialResultInCorrectOrder(currentRowResult);
            AddZeros(currentRowResult, depth);
            depth++;
            
            finalResult = AddCurrentResultToFinalResult(finalResult, currentRowResult);
            currentRowResult.Clear();
        }

        return finalResult;
    }
    
    private List<byte> AddCurrentResultToFinalResult(List<byte> result, List<byte> partialResult)
    {
        return result.Any() ? ProcessColumnDigits(result, partialResult, Addition).Reverse().ToList() : partialResult.ToList();
    }
    
    private (byte result, byte carry) MultiplyDigits(byte firstDigit, byte secondDigit, byte carry)
    {
        var multiplied = firstDigit * secondDigit + carry;
        return ((byte) (multiplied % 10), (byte) (multiplied / 10));
    }
    
    private void AddZeros(List<byte> digits, int count)
    {
        for (int i = 0; i < count; i++)
        {
            digits.Add(Zero);
        }
    }
    
    private void AddCarryIfNeeded(List<byte> digits, byte carry)
    {
        if (carry > 0)
        {
            digits.Add(carry);
        }
    }
    
    private void SortPartialResultInCorrectOrder(List<byte> partialResult) => partialResult.Reverse();
}