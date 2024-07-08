using hrnk.Data;
using hrnk.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hrnk.Controllers
{
    public class RolesController : Controller

        
    {
        private readonly hrnkDbcontext _context;


        public RolesController(hrnkDbcontext context)
        {
            _context = context;
        }



        // GET: RolesController
        public async Task<IActionResult> Index()
        {
            ViewBag.Role = _context.Roles.ToList();
            return _context.Roles != null ?
                        View(await _context.Roles.ToListAsync()) :
                        Problem("Entity set 'hrnkDbcontext.Roles'  is null.");
        }

        // GET: RolesController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(x=> x.role_id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: RolesController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("role_name")] Role role)
        {
            if (ModelState.IsValid)
            {
                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: RolesController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(x => x.role_id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Edit(int id, [Bind("role_name")] Role role)
        {
            var res = await _context.Roles.Where(x => x.role_id == id).ToListAsync();

            if (res == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid) {
            try
            {
                    res[0].role_name = role.role_name;
                    _context.Roles.Update(res[0]);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            }
            return View();
        }

        // GET: RolesController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.role_id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'hrnkDbcontext.User'  is null.");
            }
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
