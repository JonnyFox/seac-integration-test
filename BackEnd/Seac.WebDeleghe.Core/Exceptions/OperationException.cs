using System;

namespace Seac.WebDeleghe.Core.Exceptions
{
    public abstract class OperationException : Exception
    {
        protected OperationException(string message = null, Exception innerException = null)
            : base(message, innerException)
        { }
    }
}