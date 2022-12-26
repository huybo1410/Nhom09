using Microsoft.AspNetCore.Mvc;
using Nhom09.Controllers;
using Nhom09.Models;

namespace Nhom09.Controllers
{
    public class CheckOutsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
