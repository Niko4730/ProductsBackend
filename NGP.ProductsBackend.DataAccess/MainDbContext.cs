using Microsoft.EntityFrameworkCore;
using NGP.ProductsBackend.DataAccess.Entities;

namespace NGP.ProductsBackend.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options) {}
        public DbSet<ProductEntity> Products { get; set; }

    }
}