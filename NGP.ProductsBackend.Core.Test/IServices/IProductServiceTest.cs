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
        
    }
}