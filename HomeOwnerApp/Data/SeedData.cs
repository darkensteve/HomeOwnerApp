using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HomeOwnerApp.Models;

namespace HomeOwnerApp.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check if we already have any users
                if (context.Users.Any())
                {
                    return; // Database has been seeded
                }

                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Create admin user
                var adminUser = new ApplicationUser
                {
                    UserName = "darkenstevei@example.com",
                    Email = "darkenstevei@example.com",
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "Admin@123456");
            }
        }
    }
}