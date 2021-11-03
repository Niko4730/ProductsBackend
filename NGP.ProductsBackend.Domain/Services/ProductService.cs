using System;
using System.Collections.Generic;
using System.IO;
using NGP.ProductsBackend.Domain.IRepositories;
using NGP.WebShop2021.Core.IServices;
using NGP.WebShop2021.Core.Models;

namespace NGP.ProductsBackend.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new InvalidDataException("ProductRepository cannot be null");
            }

            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.ReadAll();
        }
    }
}