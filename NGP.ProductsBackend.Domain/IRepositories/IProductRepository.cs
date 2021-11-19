using System.Collections.Generic;
using NGP.WebShop2021.Core.Models;

namespace NGP.ProductsBackend.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> ReadAll();

        Product ReadById(int id);

        Product Create(int id, string name);

        Product Delete(int id);

        Product Update(int id, Product product);
    }
}