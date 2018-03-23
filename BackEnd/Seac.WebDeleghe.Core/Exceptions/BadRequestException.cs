namespace Seac.WebDeleghe.Core.Exceptions
{
    public class BadRequestException : OperationException
    {
        public readonly object Cause;

        public BadRequestException(object cause = null)
        {
            Cause = cause;
        }
    }
}