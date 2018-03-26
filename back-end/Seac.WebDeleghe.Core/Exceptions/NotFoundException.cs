namespace Seac.WebDeleghe.Core.Exceptions
{
    public sealed class NotFoundException : OperationException
    {
        public NotFoundException(string message = null) : base(message)
        { }
    }
}