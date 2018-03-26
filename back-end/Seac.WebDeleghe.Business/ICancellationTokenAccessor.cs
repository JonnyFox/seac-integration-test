using System.Threading;

namespace Seac.WebDeleghe.Business
{
    /// <summary>
    /// Accesses the cancellation token that can cancel any operation
    /// </summary>
    public interface ICancellationTokenAccessor
    {
        CancellationToken CancellationToken { get; }
    }
}