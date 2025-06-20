namespace BigNumbers.ArithmeticOperations;

public class ColumnAdditionStrategy : ColumnOperationAbstractStrategy, IColumnOperation
{
    public IList<byte> Count(IList<byte> firstNumber, IList<byte> secondNumber)
    {
        return ProcessColumnDigits(firstNumber, secondNumber, Addition)
            .Reverse().ToList(); // Reverse the result to get the correct order of digits
    }
}