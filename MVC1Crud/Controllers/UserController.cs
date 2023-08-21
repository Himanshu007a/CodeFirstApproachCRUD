using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1Crud.Data;
using MVC1Crud.Models;

namespace MVC1Crud.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _context.Users.ToListAsync();
            
            return View(model) ;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "User");

            }
            return View(user);
        }
          public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Users == null)
            {
                return NotFound();
            }
            var model = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _context.Users.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "User");
            }
            return View(user);
        }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var model = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var model = await _context.Users.FindAsync(id);
            if (model != null)
            {
                _context.Users.Remove(model);  
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "User");
        }

    }
}
