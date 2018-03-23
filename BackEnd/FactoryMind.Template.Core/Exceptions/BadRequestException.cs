namespace FactoryMind.Template.Core.Exceptions
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