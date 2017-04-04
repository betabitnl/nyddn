using Demo.EfCore.Standard.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Demo.EFCore.NetCore.UnitTests
{
    public class InMemoryTests
    {
        [Fact]
        public void ExampleTest1()
        {
            var options = new DbContextOptionsBuilder<AwDbContext>()
               .UseInMemoryDatabase(databaseName: "ExampleTest1")
               .Options;

            //Arrange
            using (var context = new AwDbContext(options))
            {
                context.Product.AddRange(Enumerable.Range(1, 100).Select(x => new Product { Name = $"Product{x}" }));
                context.Product.Add(new Product
                {
                    Name = "product with category",
                    ProductCategory = new ProductCategory
                    {
                        Name = "category1"
                    }
                });

                context.SaveChanges();
            }

            using (var context = new AwDbContext(options))
            {
                //Act
                var productCountInCategory1 = context.Product.Count(x => x.ProductCategory.Name == "category1");
                var otherProducts = context.Product.Count(x => x.ProductCategory.Name != "category1");

                //Assert
                Assert.Equal(1, productCountInCategory1);
                Assert.Equal(100, otherProducts);
            }
        }

    }
}