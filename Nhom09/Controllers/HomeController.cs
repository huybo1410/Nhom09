using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nhom09.Admin.Models;
using Nhom09.Data;
using Nhom09.Models;
using Nhom09.Utilities;
using System.Diagnostics;


namespace Nhom09.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private shopsamsungContext _context;

        public HomeController(ILogger<HomeController> logger, shopsamsungContext context)
        {
            _logger = logger;
            _context = context;
        }
        

        [Authentication]
        public IActionResult Index()
        {
            
            return View();
        }

        [Authentication]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            
            if (HttpContext.Session.GetString("Username")== null)
            {
                if (ModelState.IsValid)
                {
                    
                        var status = _context.Customers.Where(a => 
                        a.Username.Equals(customer.Username) && 
                        a.Password.Equals(customer.Password)).FirstOrDefault();
                        if (status != null)
                        {
                            HttpContext.Session.SetString("Username", status.Username);
                            return RedirectToAction("Index");
                        }
                    
                    
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }

    }
}