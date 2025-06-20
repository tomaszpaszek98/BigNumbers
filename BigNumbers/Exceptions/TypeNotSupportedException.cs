namespace BigNumbers.Exceptions;

public class TypeNotSupportedException : Exception
{
    public TypeNotSupportedException(string message) : base(message)
    {
    }
}