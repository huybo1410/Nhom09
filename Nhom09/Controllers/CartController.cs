using Microsoft.AspNetCore.Mvc;

namespace Nhom09.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
