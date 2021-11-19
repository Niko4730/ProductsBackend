using System.Collections.Generic;
using System.Reflection.Metadata;
using Moq;
using NGP.WebShop2021.Core.IServices;
using NGP.WebShop2021.Core.Models;
using Xunit;

namespace NGP.ProductsBackend.Core.Test
{
    public class IProductServiceTest
    {
        [Fact]
        public void IProductService_Exists()
        {
            var serviceMock = new Mock<IProductService>();
                Assert.NotNull(serviceMock.Object);
        }

        [Fact]
        public void GetALl_WithNoParams_ReturnsListOfProducts()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock
                .Setup(s => s.GetAll())
                .Returns(new List<Product>());
            Assert.NotNull(serviceMock.Object.GetAll());
        }

        [Fact]
        public void GetById_NotNull()
        {
            var serviceMock = new Mock<IProductService>();
            var expectedId = 1;
            serviceMock
                .Setup(s => s.GetById(expectedId))
                .Returns(new Product());
            Assert.NotNull(serviceMock.Object.GetById(expectedId));
        }

        [Fact]
        public void Create_NotNull()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(s => s.Create(1, "Product1"))
                .Returns(new Product());
            Assert.NotNull(serviceMock.Object.Create(1 ,"Product1"));
        }

        [Fact]
        public void Delete_NotNull()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(s => s.Delete(1))
                .Returns(new Product());
            Assert.NotNull(serviceMock.Object.Delete(1));
        }

        [Fact]
        public void Update_NotNull()
        {
            var serviceMock = new Mock<IProductService>();
            var expectedProduct = new Product {Id = 1, Name = "Product4"};
            serviceMock.Setup(s => s.Update(1, expectedProduct))
                .Returns(new Product());
            Assert.NotNull(serviceMock.Object.Update(1, expectedProduct));
        }
        
    }
}