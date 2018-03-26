using FactoryMind.Template.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FactoryMind.Template.Business.Tests.Configuration
{
    internal sealed class TestDbContextConfigurator : IDbContextConfigurator
    {
        public void ConfigureDbSet(DbContextOptionsBuilder builder) => builder
            .UseInMemoryDatabase("test")
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
    }
}