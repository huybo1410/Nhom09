using Microsoft.AspNetCore.Mvc;

namespace Nhom09.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
