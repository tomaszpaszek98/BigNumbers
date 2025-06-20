namespace BigNumbers.ArithmeticOperations;

public static class ColumnOperations
{
    public static IColumnOperation Add = new ColumnAdditionStrategy();
    public static IColumnOperation Subtract = new ColumnSubtractionStrategy();
    public static IColumnOperation Multiply = new ColumnMultiplicationStrategy();
}