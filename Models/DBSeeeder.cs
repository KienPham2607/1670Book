using _1670Book.Constants;
using _1670Book.Data;
using Microsoft.AspNetCore.Identity;

namespace _1670Book.Models
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Staff.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // Create admin
            var userAdmin = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "No Name Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userAdminInDb = await userManager.FindByEmailAsync(userAdmin.Email);
            if (userAdminInDb == null)
            {
                await userManager.CreateAsync(userAdmin, "Admin@123");
                await userManager.AddToRoleAsync(userAdmin, Roles.Admin.ToString());
            }

            // Create staff
            var userStaff = new ApplicationUser
            {
                UserName = "staff@gmail.com",
                Email = "staff@gmail.com",
                Name = "No Name Staff",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userStaffInDb = await userManager.FindByEmailAsync(userStaff.Email);
            if (userAdminInDb == null)
            {
                await userManager.CreateAsync(userStaff, "Staff@123");
                await userManager.AddToRoleAsync(userStaff, Roles.Staff.ToString());
            }
        }

    }
}
