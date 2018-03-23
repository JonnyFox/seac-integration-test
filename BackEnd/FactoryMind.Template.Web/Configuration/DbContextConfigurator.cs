using FactoryMind.Template.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FactoryMind.Template.Web.Configuration
{
    internal sealed  class DbContextConfigurator : IDbContextConfigurator
    {
        public void ConfigureDbSet(DbContextOptionsBuilder builder) =>
            builder.UseSqlite(@"Data Source=app.db");
    }
}