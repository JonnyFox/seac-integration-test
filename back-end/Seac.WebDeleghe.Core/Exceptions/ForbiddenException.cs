namespace Seac.WebDeleghe.Core.Exceptions
{
    public sealed class ForbiddenException : OperationException
    {
        public ForbiddenException(string message = null) : base(message)
        { }
    }
}