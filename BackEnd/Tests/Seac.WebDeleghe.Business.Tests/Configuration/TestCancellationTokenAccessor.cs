using System.Threading;

namespace Seac.WebDeleghe.Business.Tests.Configuration
{
    internal sealed class TestCancellationTokenAccessor : ICancellationTokenAccessor
    {
        public CancellationToken CancellationToken { get; } = default(CancellationToken);
    }
}