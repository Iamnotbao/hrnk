using hrnk.Data;
using hrnk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hrnk.Controllers
{
    public class ProfileController : Controller
    {

        private hrnkDbcontext _context;

        public ProfileController(hrnkDbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<ActionResult> ProfileAdmin(long? id)
        {

            if (id == null)
            {
                return NotFound();

            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();

            }
            
            return View(user);
        }


        [HttpGet]
        public async Task<ActionResult> ProfileEdit(long? id)
        {

            if (id == null)
            {
                return NotFound();

            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();

            }
            ViewBag.ID = id;
            ViewBag.Role = _context.Roles.ToList();
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> ProfileEdit(long? id, [Bind("username,password,confirmpassword")] Registers reg, int role)
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
                    _context.SaveChanges();
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
            }

            return RedirectToAction("Index", "Users"); ;
        }
        private bool UserExists(long id)
        {
            return (_context.User?.Any(e => e.userid == id)).GetValueOrDefault();
        }
    }
}
