using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Nhom09.Data;
using Nhom09.Models;

namespace Nhom09.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly shopsamsungContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(shopsamsungContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
      
        // GET: Admin/Products
       
        public async Task<IActionResult> Index(string searchString)
        {
            var products = from m in _context.Products.Include(p => p.ProductType)
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }

            return View(await products.ToListAsync());
        }
        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Quantity,Image,ImageFile,ProductTypeId,Chip,RAM,ScreenSize,Pin")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                if (product.ImageFile != null)
                {
                    var fileName = product.Id.ToString() + Path.GetExtension(product.ImageFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "ImageSP");
                    var uploadPath = Path.Combine(uploadFolder, fileName);
                    using (FileStream fs = System.IO.File.Create(uploadPath))
                    {
                        product.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    product.Image = fileName;
                    _context.Products.Update(product);
                     _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            return View(product);
            
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity,Image,ImageFile,ProductTypeId,Chip,RAM,ScreenSize,Pin")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageFile != null)
                    {
                        var fileName = product.Id.ToString() + Path.GetExtension(product.ImageFile.FileName);
                        var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "ImageSP");
                        var uploadPath = Path.Combine(uploadFolder, fileName);
                        using (FileStream fs = System.IO.File.Create(uploadPath))
                        {
                            product.ImageFile.CopyTo(fs);
                            fs.Flush();
                        }
                        product.Image = fileName;
                        _context.Products.Update(product);
                        _context.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            return View(product);
        }
      /*  public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity,Image,ImageFile,ExistingImagePath,ProductTypeId,Chip,RAM,ScreenSize,Pin")] Product product)
        {
            if (product.ImageFile == null || product.ImageFile.Length == 0)
            {
                return Content("File not selected");
            }
            //Save The Picture In folder
            var path = Path.Combine(_environment.WebRootPath, "img/ImageSP", product.ImageFile.FileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(stream);
                stream.Close();
            }

            //Bind Picture info to model
            product.Image = product.ImageFile.FileName;

            //Finding the member by its Id which we would update
            var objProduct = _context.Products.Where(mId => mId.Id == product.Id).FirstOrDefault();

            if (objProduct != null)
            {
                //Update the existing member with new value
                objProduct.Name = product.Name;
                objProduct!.Price = product.Price;
                objProduct!.Quantity = product.Quantity;
                objProduct!.Image = product.Image;
                objProduct!.ProductTypeId = product.ProductTypeId;
                objProduct!.Chip = product.Chip;
                objProduct!.RAM = product.RAM;
                objProduct!.ScreenSize = product.ScreenSize;
                objProduct!.Pin = product.Pin;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            return View(product);

        }*/

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'shopsamsungContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Products.Any(e => e.Id == id);
        }
    }
}
