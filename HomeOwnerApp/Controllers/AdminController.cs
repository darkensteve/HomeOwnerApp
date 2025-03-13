using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HomeOwnerApp.Data;
using HomeOwnerApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOwnerApp.Controllers
{
    [Authorize(Roles = "Admin")] // ✅ Restrict access to Admin role only
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // 🔹 Redirect unauthenticated users to login
            }

            var homeowners = _context.Homeowners.ToList();
            var model = new Tuple<ApplicationUser, List<Homeowner>>(user, homeowners);
            return View(model);
        }
    }
}
