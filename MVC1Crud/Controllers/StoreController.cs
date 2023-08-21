
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1Crud.Data;
using MVC1Crud.Models;

namespace MVC1Crud.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

 [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stores = await _context.Stores.ToListAsync();
            return View(stores);
        }

      
        public IActionResult Create()
        {

            var model = _context.Stores.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Store store)
        {
            if (ModelState.IsValid)
            {
                await _context.Stores.AddAsync(store);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "User");

            }
            return View(store);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound(id);
            }
            var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            if (store == null)
            {
                return NotFound();
            }
            return View(store);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id); 
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Store store)
        {
            if (id != store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Stores.Update(store);  
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Store");
            }

            return View(store);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var model = await _context.Stores.FindAsync(id);
            if (model != null)
            {
                _context.Stores.Remove(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Store");
        }
    }
}
