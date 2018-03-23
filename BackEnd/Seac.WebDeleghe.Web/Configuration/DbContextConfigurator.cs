using Seac.WebDeleghe.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Seac.WebDeleghe.Web.Configuration
{
    internal sealed  class DbContextConfigurator : IDbContextConfigurator
    {
        public void ConfigureDbSet(DbContextOptionsBuilder builder) =>
            builder.UseSqlite(@"Data Source=app.db");
    }
}