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
            //ViewBag.username = HttpContext.Session.GetString("username");
            //return View();
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