using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using HomeOwnerApp.Data; // ✅ Ensure this is included
using HomeOwnerApp.Models;

namespace HomeOwnerApp.Views.Admin
{
    [Authorize]
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Homeowner> Homeowners { get; set; } = new();

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Homeowners = _context.Homeowners.ToList(); // ✅ Fetch homeowners from DB
        }
    }
}
