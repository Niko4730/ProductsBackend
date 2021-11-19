using System.Collections.Generic;
using NGP.WebShop2021.Core.Models;

namespace NGP.WebShop2021.Core.IServices
{
    public interface IProductService
    {
       List<Product> GetAll();
       Product GetById(int id);
       Product Create(int id, string name);
       Product Delete(int id);
       Product Update(int id, Product product);
    }
}