using System;

namespace FactoryMind.Template.Core.Exceptions
{
    public abstract class OperationException : Exception
    {
        protected OperationException(string message = null, Exception innerException = null)
            : base(message, innerException)
        { }
    }
}