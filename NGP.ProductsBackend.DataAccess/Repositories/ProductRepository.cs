using System.Collections.Generic;
using System.Linq;
using NGP.ProductsBackend.DataAccess.Entities;
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

        public Product ReadById(int id)
        {
            var pe = _ctx.Products
                .FirstOrDefault(pe => pe.Id == id);
            return new Product {Id = pe.Id, Name = pe.Name};
        }

        public Product Create(int id, string name)
        {
            var pe = new Product
            {
                Id = id,
                Name = name
            };
            _ctx.Products.Add(new ProductEntity {Id = pe.Id, Name = pe.Name});
            _ctx.SaveChanges();
            return pe;
        }

        public Product Delete(int id)
        {
            var pe = _ctx.Products
                .FirstOrDefault(pe => pe.Id == id);
            _ctx.Products.Remove(pe);
            _ctx.SaveChanges();
            return new Product {Id = pe.Id, Name = pe.Name};
        }

        public Product Update(int id, Product product)
        {
            var pe = _ctx.Products
                .FirstOrDefault(pe => pe.Id == id);
            pe.Name = product.Name;
            _ctx.Products.Update(pe);
            _ctx.SaveChanges();
            return product;
        }
    }
}