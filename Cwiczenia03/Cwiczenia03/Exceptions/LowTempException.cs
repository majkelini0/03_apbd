namespace Cwiczenia03.Exceptions;

public class LowTempException : Exception
{
    public LowTempException(string? message) : base(message)
    {
        Console.WriteLine(message + " OverFillException");
    }
}