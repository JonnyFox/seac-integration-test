using System.Threading;

namespace FactoryMind.Template.Business
{
    /// <summary>
    /// Accesses the cancellation token that can cancel any operation
    /// </summary>
    public interface ICancellationTokenAccessor
    {
        CancellationToken CancellationToken { get; }
    }
}