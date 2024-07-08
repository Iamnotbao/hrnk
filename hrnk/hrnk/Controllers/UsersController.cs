using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hrnk.Data;
using hrnk.Models;
using Microsoft.AspNetCore.Authorization;

namespace hrnk.Controllers
{
    [Authorize(Roles = "0")]
    public class UsersController : Controller
    {
        private readonly hrnkDbcontext _context;

        public UsersController(hrnkDbcontext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            ViewBag.Role = _context.Roles.ToList();
            return _context.User != null ?
                        View(await _context.User.ToListAsync()) :
                        Problem("Entity set 'hrnkDbcontext.User'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.userid == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.Role = _context.Roles.ToList();
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("username,password,confirmpassword")] Registers user, int role)
        {

            if (ModelState.IsValid)
            {
                var hashPass = EncryptPassword.HashPassword(user.password);
                //var parsedRole = Enum.TryParse(role, out User.Role userRole);
                var member = new User
                {
                    username = user.username,
                    hash_password = hashPass,
                    user_create_at = DateTime.Now,
                    user_create_by = user.username,
                    role_id = role

                };
                _context.User.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Log or display the validation errors
                foreach (var state in ModelState)
                {
                    var key = state.Key;
                    var errors = state.Value.Errors;
                    foreach (var error in errors)
                    {
                        // You can log the errors or add them to the view data to display on the view
                        // For example, log the errors:
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}, Exception: {error.Exception}");
                    }
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Id = user.userid;
            ViewBag.Role = _context.Roles.ToList();
            return View();
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("username,password,confirmpassword")] Registers reg, int role)
        {

            var res = await _context.User.Where(x => x.userid == id).ToListAsync();

            if (res == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)

            {
                try
                {
                 
                    res[0].username = reg.username;
                    res[0].role_id = role;
                    _context.User.Update(res[0]);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(res[0].userid))
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
            return View();
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.userid == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'hrnkDbcontext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool UserExists(long id)
        {
            return (_context.User?.Any(e => e.userid == id)).GetValueOrDefault();
        }
    }
}
