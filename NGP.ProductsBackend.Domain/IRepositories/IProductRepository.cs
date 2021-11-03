using System.Collections.Generic;
using NGP.WebShop2021.Core.Models;

namespace NGP.ProductsBackend.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
    }
}