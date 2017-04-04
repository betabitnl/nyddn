using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Demo.EfCore.Standard.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetMVC.Controllers
{
    public class ProductsController : Controller
    {
        private AwDbContext _context;

        public ProductsController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AwDbContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AwDbContext"].ConnectionString);
            _context = new AwDbContext(optionsBuilder.Options);
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(_context.Product.ToList());
        }
    }
}