using System.Threading.Tasks;
using Seac.WebDeleghe.Business.Commands;
using Seac.WebDeleghe.Business.Tests.Infrastructure;
using Seac.WebDeleghe.Data;
using Seac.WebDeleghe.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Seac.WebDeleghe.Business.Tests.Products
{
    public class CreateProductCommandTests : BaseTest
    {
        [Fact]
        public async Task Should_CreateProduct_When_CreatingProduct()
        {
            //Arrange
            var context = Resolve<ApplicationDbContext>();
            var productToCreate = new ProductDto
            {
                Price = 1,
                Name = "Test"
            };

            //Act
            await InvokeCommandAsync(new CreateProductCommand(productToCreate));
            var createdProduct = await context.Products.SingleAsync();

            //Assert
            Assert.Equal(productToCreate.Name, createdProduct.Name);
            Assert.Equal(productToCreate.Price, createdProduct.Price);
        }
    }
}