using Microsoft.AspNetCore.Mvc;
using Nhom09.Data;
using Nhom09.Models;

namespace Nhom09.Controllers
{
    public class LoginController : Controller

    {
        private shopsamsungContext _context;
        public LoginController(shopsamsungContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Customer _customer = new Customer();

            return View(_customer);
        }

        [HttpPost]
        public IActionResult Index(Customer _customer)
        {
            var status = _context.Customers.Where(m => m.Username == _customer.Username && m.Password == _customer.Password).FirstOrDefault();
            if(status != null)
            {
                HttpContext.Session.SetString("username", _customer.Username);
                return RedirectToRoute("Home");
            }
            else
            {
                ViewBag.msg = "Invalid";
                return View(_customer);
            }
            
        }

        public IActionResult SuccecssPage()
        {
            return View();
        }


    }
}
