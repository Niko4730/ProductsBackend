using NGP.WebShop2021.Core.Models;
using Xunit;

namespace NGP.ProductsBackend.Core.Test.Models
{
    public class ProductTest
    {
        [Fact]
        public void Product_Exists()
        {
            var product = new Product();
                Assert.NotNull(product);
        }

        [Fact]
        public void Product_HasIntProperty_Id()
        {
            var expected = (int)1;
            var product = new Product();
            product.Id = expected;
            Assert.Equal(expected, product.Id);
        }

        [Fact]
        public void Product_HasStringProperty_Name()
        {
            var expected = (string) "Ko";
            var product = new Product();
            product.Name = expected;
            Assert.Equal(expected, product.Name);
        }
    }
}