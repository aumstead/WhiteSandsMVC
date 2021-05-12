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
                new IdentityRole{Name = "Employee"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Gandalf1");
                await userManager.AddToRoleAsync(user, "Employee");
            }

            var member = new ApplicationUser
            {
                UserName = "pete@scdp.com",
                Email = "pete@scdp.com",
                FirstName = "Pete",
                LastName = "Campbell",
                Title = "Mr."
            };

            await userManager.CreateAsync(member, "Gandalf1");
            await userManager.AddToRoleAsync(member, "Member");

            var admin = new ApplicationUser
            {
                UserName = "admin@whitesands.com",
                Email = "admin@whitesands.com",
                FirstName = "Admin",
                LastName = "Admin"
            };

            await userManager.CreateAsync(admin, "Gandalf1");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        public static async Task SeedGuests(AppDbContext context)
        {
            if (await context.Guests.AnyAsync()) return;

            var guestsData = await System.IO.File.ReadAllTextAsync("Models/SeedData/GuestsSeedData.json");

            var guests = JsonSerializer.Deserialize<List<Guest>>(guestsData);

            foreach (var guest in guests)
            {
                context.Guests.Add(guest);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedBillsOfSale(AppDbContext context)
        {
            if (await context.BillsOfSale.AnyAsync()) return;

            var billsOfSaleData = await System.IO.File.ReadAllTextAsync("Models/SeedData/BillsOfSaleSeedData.json");

            var billsOfSale = JsonSerializer.Deserialize<List<BillOfSale>>(billsOfSaleData);

            foreach (var bill in billsOfSale)
            {
                context.BillsOfSale.Add(bill);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedBookings(AppDbContext context)
        {
            if (await context.Bookings.AnyAsync()) return;

            var bookingsData = await System.IO.File.ReadAllTextAsync("Models/SeedData/BookingsSeedData.json");

            var bookings = JsonSerializer.Deserialize<List<Booking>>(bookingsData);

            foreach (var booking in bookings)
            {
                context.Bookings.Add(booking);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedLineItemCharges(AppDbContext context)
        {
            if (await context.LineItemCharges.AnyAsync()) return;

            var lineItemChargesData = await System.IO.File.ReadAllTextAsync("Models/SeedData/LineItemChargesSeedData.json");

            var lineItemCharges = JsonSerializer.Deserialize<List<LineItemCharge>>(lineItemChargesData);

            foreach (var charge in lineItemCharges)
            {
                context.LineItemCharges.Add(charge);
            }

            await context.SaveChangesAsync();
        }
    }
}
