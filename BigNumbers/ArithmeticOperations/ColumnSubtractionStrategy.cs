namespace BigNumbers.ArithmeticOperations;

public class ColumnSubtractionStrategy : ColumnOperationAbstractStrategy, IColumnOperation
{
    public IList<byte> Count(IList<byte> firstNumber, IList<byte> secondNumber)
    {
        return  ProcessColumnDigits(firstNumber, secondNumber, Subtraction)
            .Reverse().ToList(); // Reverse the result to get the correct order of digits
    }
}