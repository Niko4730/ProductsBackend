using System.Collections.Generic;
using NGP.ProductsBackend.DataAccess.Entities;

namespace NGP.ProductsBackend.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Products.Add(new ProductEntity {Name = "Product 1"});
            _ctx.Products.Add(new ProductEntity {Name = "Product 2"});
            _ctx.Products.Add(new ProductEntity {Name = "Product 3"});
         
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
        }
    }
}