using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NGP.ProductsBackend.Domain.IRepositories;
using NGP.ProductsBackend.Domain.Services;
using NGP.WebShop2021.Core.IServices;
using NGP.WebShop2021.Core.Models;
using Xunit;

namespace NGP.ProductsBackend.Domain.Test.Services
{
    public class ProductServiceTest
    {
        #region ProductService Initialization Tests
        [Fact]
        public void ProductService_IsIProductService()
        {
            var mockRepo = new Mock<IProductRepository>();
            var productService = new ProductService(mockRepo.Object);
            Assert.IsAssignableFrom<IProductService>(productService);
        }

        [Fact]
        public void ProductService_WithNullRepository_ThrowsInvalidDataException()
        {
            Assert
                .Throws<InvalidDataException>(() => new ProductService(null));
        }
        [Fact]
        public void ProductService_WithNullRepository_ThrowsExceptionWithMessage()
        {
            var ex = Assert
                .Throws<InvalidDataException>(() => new ProductService(null));
            Assert.Equal("ProductRepository cannot be null", ex.Message);
        }
        #endregion


        #region ProductService GetALl

        [Fact]
        public void GetAll_NoParams_CallsProductRepositoryOnce()
        {
            var mockRepo = new Mock<IProductRepository>();
            var productService = new ProductService(mockRepo.Object);

            productService.GetAll();

            mockRepo.Verify(r => r.ReadAll(), Times.Once());
        }
        [Fact]
        public void GetAll_NoParams_ReturnsAllProductsAsList()
        {
            var expected = new List<Product> {new Product {Id = 1, Name = "Ko"}};
            var mockRepo = new Mock<IProductRepository>();
            mockRepo
                .Setup(r => r.ReadAll())
                .Returns(expected);
            var productService = new ProductService(mockRepo.Object);

            productService.GetAll();

            Assert.Equal(expected, productService.GetAll(), new ProductComparer());
        }
        

        #endregion
    }

    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(Product obj)
        {
            return HashCode.Combine(obj.Id, obj.Name);
        }
    }
}