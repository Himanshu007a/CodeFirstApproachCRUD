using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1Crud.Data;
using MVC1Crud.Models;

namespace MVC1Crud.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<IActionResult> Index()
        {
            var groups = await _context.Groups.ToListAsync();
            return View(groups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        // this validation makes our method secure from the hacker
        public async Task<IActionResult> Create(Group group)
        {
            if (ModelState.IsValid)
            {
                 await _context.Groups.AddAsync(group);
                 await _context.SaveChangesAsync(); 
                return RedirectToAction("Index","Group");
            }

            return View(group);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound(id);
            }
            var groups = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if(groups == null)
            {
                return NotFound();
            }
            return View(groups);
        }
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound(id);
            }
            var groups = await _context.Groups.FindAsync(id);
            if (groups == null)
            {
                return NotFound();
            }
            return View(groups);
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id, Group group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                  _context.Groups.Update(group);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Group");
            }
          
            return View(group);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound(id);
            }
            var groups = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);    
            if (groups == null)
            {
                return NotFound();
            }
            return View(groups);
        }
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var model = await _context.Groups.FindAsync(id);
            if (id != null)
            {
                 _context.Groups.Remove(model);
               
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Group");
        }

    }
}
