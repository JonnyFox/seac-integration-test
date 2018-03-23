namespace FactoryMind.Template.Core.Exceptions
{
    public sealed class UnauthorizedException: OperationException
    {
        public UnauthorizedException(string message = null) : base(message)
        { }
    }
}