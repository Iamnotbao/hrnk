using Microsoft.AspNetCore.Mvc;
using hrnk.Data;
using hrnk.Models;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace hrnk.Controllers
{
    public class LoginController : Controller
    {
        // GET Admin/Login
        private readonly hrnkDbcontext _context;

        public LoginController(hrnkDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Registers reg)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.FirstOrDefault(x => x.username == reg.username);
                if (user == null)
                {
                    var hashPass = EncryptPassword.HashPassword(reg.password);
                    user = new User
                    {
                        username = reg.username,
                        hash_password = hashPass,
                        user_create_at = DateTime.Now,
                        user_create_by = reg.username,
                        role_id = 1,
                    };
                    _context.User.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username already exists.");
                }
            }
            return View(reg);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView log)
        {
            if (ModelState.IsValid)
            {
                User user = _context.User.FirstOrDefault(x => x.username.Equals(log.username));
                if (user != null)
                {
                    bool isPasswordValid = EncryptPassword.VerifyPassword(log.password, user.hash_password);
                    if (isPasswordValid)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.username),
                            new Claim(ClaimTypes.Role,user.role_id.ToString()),
                            new Claim("UserId", user.userid.ToString()),
                            new Claim("LastChanged", user.user_update_at.ToString())
                            // Add more claims as needed
                        };

                        var claimsIdentity = new ClaimsIdentity(
                            claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(5)
                        });

                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(log);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return LocalRedirect(returnUrl);
        }


    }
}
