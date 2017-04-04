using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Demo.EfCore.Standard.Models;
using Demo02.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo02.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ILogger<ProductsController> _logger;
        private AwDbContext _awDbContext;

        //TODO: EF1.2 show injection and queries in controller
        public ProductsController(ILoggerFactory loggerFactory, AwDbContext awDbContext)
        {
            _logger = loggerFactory.CreateLogger<ProductsController>();
            _awDbContext = awDbContext;
        }


        [HttpGet]
        public IEnumerable<ProductListItem> Get()
        {
            return _awDbContext.Product
                .Include(p => p.ProductCategory)
                .ToList()
                .Select(p => new ProductListItem
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    CategoryName = p.ProductCategory?.Name
                });
        }

        [HttpGet("{id}")]
        public ProductDetails Get(int id)
        {
            var product = _awDbContext.Product
                 .Include(p => p.ProductCategory)
                 .Single(p => p.ProductId == id);

            return new ProductDetails
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.ProductCategoryId,
                CategoryName = product.ProductCategory?.Name
            };
        }


    }
}
