﻿using Microsoft.AspNetCore.Mvc;

namespace Nhom09.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
