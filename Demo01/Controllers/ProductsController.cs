using System.Linq;

using Demo.EfCore.Standard.Models;
using Demo01.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class ProductsController : Controller
    {
        AwDbContext _context;

        public ProductsController(AwDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Product.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            return RedirectToAction("blah");
        }
    }
}