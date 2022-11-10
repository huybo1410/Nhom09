using Microsoft.AspNetCore.Mvc;

namespace Nhom09.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
