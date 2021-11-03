using System.Collections.Generic;
using NGP.WebShop2021.Core.Models;

namespace NGP.WebShop2021.Core.IServices
{
    public interface IProductService
    {
       List<Product> GetAll();
    }
}