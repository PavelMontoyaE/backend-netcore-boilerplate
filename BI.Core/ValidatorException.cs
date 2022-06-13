namespace BI.Core;

public class ValidatorException : Exception
{
    public ValidatorException() : base()
    { }

    public ValidatorException(string message) : base(message)
    { }
}