using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.SeedData
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var usersData = await System.IO.File.ReadAllTextAsync("Models/SeedData/UserSeedData.json");

            var users = JsonSerializer.Deserialize<List<ApplicationUser>>(usersData);
            if (users == null) return;

            var roles = new List<IdentityRole>
            {
                new IdentityRole{Name = "Member"},
                new IdentityRole{Name = "Admin"},
                new IdentityRole{Name = "Moderator"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Gandalf1");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new ApplicationUser
            {
                UserName = "admin@whitesands.com",
                Email = "admin@whitesands.com"
            };

            await userManager.CreateAsync(admin, "Gandalf1");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        //public static async Task SeedRoomTypes(AppDbContext context)
        //{
        //    if (await context.RoomTypes.AnyAsync()) return;

        //    var roomTypesData = await System.IO.File.ReadAllTextAsync("Models/SeedData/RoomTypesSeedData.json");
        //}
    }
}
