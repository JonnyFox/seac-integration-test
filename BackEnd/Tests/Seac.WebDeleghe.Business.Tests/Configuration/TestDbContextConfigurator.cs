using Seac.WebDeleghe.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Seac.WebDeleghe.Business.Tests.Configuration
{
    internal sealed class TestDbContextConfigurator : IDbContextConfigurator
    {
        public void ConfigureDbSet(DbContextOptionsBuilder builder) => builder
            .UseInMemoryDatabase("test")
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
    }
}