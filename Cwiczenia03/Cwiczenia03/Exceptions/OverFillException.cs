using System.Runtime.Serialization;

namespace Cwiczenia03.Exceptions;

public class OverFillException : Exception
{
    public OverFillException()
    {
    }

    public OverFillException(string? message) : base(message)
    {
    }
}