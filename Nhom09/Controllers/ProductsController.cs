using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Nhom09.Data;
using Nhom09.Models;

namespace Nhom09.Controllers
{
    public class ProductsController : Controller
    {

        private shopsamsungContext _context;
        public ProductsController(shopsamsungContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lsProductType = _context.ProductTypes.ToList();
            ViewBag.lsProductType = lsProductType;
            return View(_context.Products.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult CategoryProducts(int? id )
        {
            var lstProduct = _context.Products.Where(x => x.ProductTypeId == id).ToList();
            var lsProductType = _context.ProductTypes.ToList();
            ViewBag.lsProductType = lsProductType;
            return View(lstProduct) ;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var product = from m in _context.Products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Name!.Contains(searchString));
            }

            return View(await product.ToListAsync());
        }

    }
}
