using Microsoft.AspNetCore.Mvc;

namespace Nhom09.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
