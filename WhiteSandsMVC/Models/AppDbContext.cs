using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<UserTravelInterest> UserTravelInterests { get; set; }
        public DbSet<UserHealthInterest> UserHealthInterests { get; set; }
        public DbSet<UserFoodInterest> UserFoodInterests { get; set; }
        public DbSet<TravelInterest> TravelInterests { get; set; }
        public DbSet<HealthInterest> HealthInterests { get; set; }
        public DbSet<FoodInterest> FoodInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            modelBuilder.Entity<ApplicationUser>()
                .Property(b => b.MattressPreference)
                .HasDefaultValue("Mattress - Signature pocket spring (medium firmness)");
            modelBuilder.Entity<ApplicationUser>()
                .Property(b => b.PillowPreference)
                .HasDefaultValue("Pillows - Feather");
            modelBuilder.Entity<ApplicationUser>()
                .Property(b => b.SmokingPreference)
                .HasDefaultValue("Non-smoking room");
        }
    }
}
