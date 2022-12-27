using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom09.Admin.Models;
using Nhom09.Data;
using Nhom09.Models;

namespace Nhom09.Controllers
{
    public class CustomerController : Controller
    {
        private shopsamsungContext _context;
       
        public CustomerController(shopsamsungContext context)
        {
            
            _context = context;
        }
         
        
        public IActionResult info()
        {
            var account = _context.Customers.Where(acc => acc.Username == User.Identity.Name).First();
            return View(account);
            
        }




        public async Task<IActionResult> Edit()
        {

            var account = _context.Customers.Where(acc => acc.Username == User.Identity.Name).First();
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,FullName,Address,Phone")]
        Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(info));
            }
            return RedirectToAction("info");
        }





    }
}
