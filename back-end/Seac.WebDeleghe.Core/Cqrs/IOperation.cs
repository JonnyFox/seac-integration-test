namespace Seac.WebDeleghe.Core.Cqrs
{
    public interface IOperation
    { }

    public interface ICommand : IOperation { }

    // ReSharper disable once UnusedTypeParameter
    public interface IQuery<in TResult> : IOperation { }
}