namespace ApiWeb.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, NotFoundException inner) : base(message, inner) { }
}

