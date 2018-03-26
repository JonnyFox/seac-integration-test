using Seac.WebDeleghe.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Seac.WebDeleghe.Data
{
    public sealed partial class ApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<EmployeeIncome> EmployeeIncome { get; set; }
    }
}