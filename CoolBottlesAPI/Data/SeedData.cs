using CoolBottlesAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CoolBottlesAPI.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create Admin role
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            // Create default admin user
            string firstName = "Nina";
            string lastName = "Kostoska";
            string userName = "Ninche";
            string adminEmail = "kostoskanina8@gmail.com";
            string adminPassword = "Admin123!";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser 
                { 
                    FirstName = firstName, 
                    LastName = lastName, 
                    UserName = userName, 
                    Email = adminEmail, 
                    EmailConfirmed = true 
                };
                await userManager.CreateAsync(admin, adminPassword);
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
