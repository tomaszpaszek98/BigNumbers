namespace BigNumbers.ArithmeticOperations;

public interface IColumnOperation
{
    IList<byte> Count(IList<byte> firstNumber, IList<byte> secondNumber);
}