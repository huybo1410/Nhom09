using Microsoft.AspNetCore.Mvc;

namespace Nhom09.Areas.Admin.Controllers
{
    public class productsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
