using Microsoft.AspNetCore.Mvc;
using Nhom09.Data;
using Nhom09.Models;

namespace Nhom09.Controllers
{
    public class RegisterController : Controller
    {
        private shopsamsungContext _context;
        public RegisterController(shopsamsungContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            try
            {
                var accounts = new Customer()
                {
                    Username = customer.Username,
                    Password = customer.Password,
                    Address = customer.Address,
                    FullName = customer.FullName,
                    Sex = customer.Sex,
                    Phone = customer.Phone,
                };
                _context.Customers.Add(accounts);
                _context.SaveChanges();
                ViewBag.Status = 1;

            }
            catch
            {
                ViewBag.Status = 0;
            }
            return View();
        }
    }
}
