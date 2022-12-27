using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom09.Data;
using Nhom09.Models;
using System.Diagnostics;

namespace Nhom09.Controllers
{
    public class HomeController : Controller
    {
        private shopsamsungContext _context;
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(shopsamsungContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lsProductType = _context.ProductTypes.ToList();
            ViewBag.lsProductType = lsProductType;
            return View(_context.Products.ToList());
        }
        public IActionResult AllProduct()
        {
            var lsProductType = _context.ProductTypes.ToList();
            ViewBag.lsProductType = lsProductType;
            return View(_context.Products.ToList());
        }
        public IActionResult Search(int? id)
        {
            var lsProductType = _context.ProductTypes.ToList();
            ViewBag.lsProductType = lsProductType;

            if (id == null)
            {
                return View(_context.Products.ToList());
               
            }
            var lstProduct = _context.Products.Where(x => x.ProductTypeId == id).ToList();
            lsProductType = _context.ProductTypes.ToList();
            ViewBag.lsProductType = lsProductType;
            return View(lstProduct);
           


        }
        public async Task<IActionResult> Searchs(string searchString)
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
            var lsProductType = _context.ProductTypes.ToList();
            ViewBag.lsProductType = lsProductType;
            return View(await product.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}