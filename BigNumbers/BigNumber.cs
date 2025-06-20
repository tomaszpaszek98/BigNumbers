using BigNumbers.ArithmeticOperations;
using BigNumbers.Extensions;

namespace BigNumbers;

public class BigNumber
{
    public IList<byte> Digits { get; }
    
    public BigNumber(IList<byte> digits)
    {
        Digits = digits;
    }

    public static BigNumber operator +(BigNumber firstNumber, BigNumber secondNumber)
    {
        var resultList =  ColumnOperations.Add.Count(firstNumber.Digits, secondNumber.Digits);
        
        return new BigNumber(resultList.TrimRedundantZeros());
    }
    
    public static BigNumber operator -(BigNumber firstNumber, BigNumber secondNumber)
    {
        var resultList = ColumnOperations.Subtract.Count(firstNumber.Digits, secondNumber.Digits);
        
        return new BigNumber(resultList.TrimRedundantZeros());
    }
    
    public static BigNumber operator *(BigNumber firstNumber, BigNumber secondNumber)
    {
       var resultList = ColumnOperations.Multiply.Count(firstNumber.Digits, secondNumber.Digits);
       return new BigNumber(resultList.TrimRedundantZeros());
    }
    
    public override string ToString()
    {
        return string.Concat(Digits);
    }
}