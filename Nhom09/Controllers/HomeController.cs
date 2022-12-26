using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nhom09.Admin.Models;
using Nhom09.Data;
using Nhom09.Models;
using Nhom09.Utilities;
using System.Diagnostics;
using System.Security.Claims;

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


        [AllowAnonymous]
        public IActionResult Index()
        {
            
            return View();
        }

        [AllowAnonymous]
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
                            bool isValid = (status.Username == customer.Username && status.Password == customer.Password);
                            if (isValid)
                             {
                                var identity = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, customer.Username) }, 
                                CookieAuthenticationDefaults.AuthenticationScheme);
                                var principal = new ClaimsPrincipal(identity);
                                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                                HttpContext.Session.SetString("Username", status.Username);
                                return RedirectToAction("Index");

                             }
                            else
                             {
                                TempData["errorMessage"] = "Invalid password!";
                                return View(customer);
                             }
                            
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
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }

    }
}