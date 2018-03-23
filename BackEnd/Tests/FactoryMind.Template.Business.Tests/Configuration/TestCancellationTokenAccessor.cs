using System.Threading;

namespace FactoryMind.Template.Business.Tests.Configuration
{
    internal sealed class TestCancellationTokenAccessor : ICancellationTokenAccessor
    {
        public CancellationToken CancellationToken { get; } = default(CancellationToken);
    }
}