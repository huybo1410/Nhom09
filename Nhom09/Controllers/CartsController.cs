using Microsoft.AspNetCore.Mvc;

namespace Nhom09.Controllers
{
    public class CartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
