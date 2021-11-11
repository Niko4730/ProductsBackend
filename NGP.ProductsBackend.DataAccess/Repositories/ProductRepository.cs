using System.Collections.Generic;
using System.Linq;
using NGP.ProductsBackend.Domain.IRepositories;
using NGP.WebShop2021.Core.Models;

namespace NGP.ProductsBackend.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainDbContext _ctx;

        public ProductRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Product> ReadAll()
        {
            return _ctx.Products
                .Select(pe => new Product
                {
                    Id = pe.Id,
                    Name = pe.Name
                })
                .ToList();
        }
    }
}