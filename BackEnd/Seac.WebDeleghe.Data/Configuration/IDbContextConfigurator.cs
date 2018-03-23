using Microsoft.EntityFrameworkCore;

namespace Seac.WebDeleghe.Data.Configuration
{
    public interface IDbContextConfigurator
    {
        void ConfigureDbSet(DbContextOptionsBuilder builder);
    }
}
