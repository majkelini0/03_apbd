using System.Runtime.Serialization;

namespace Cwiczenia03.Exceptions;

public class OverFillException : Exception
{
    public OverFillException(string? message) : base(message)
    {
        Console.WriteLine(message + " OverFillException");
    }
}