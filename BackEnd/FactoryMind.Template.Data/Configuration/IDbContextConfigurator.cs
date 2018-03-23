using Microsoft.EntityFrameworkCore;

namespace FactoryMind.Template.Data.Configuration
{
    public interface IDbContextConfigurator
    {
        void ConfigureDbSet(DbContextOptionsBuilder builder);
    }
}
