namespace Seac.WebDeleghe.Core.Exceptions
{
    public sealed class UnauthorizedException: OperationException
    {
        public UnauthorizedException(string message = null) : base(message)
        { }
    }
}