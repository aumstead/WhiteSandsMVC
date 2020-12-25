﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            RoomType[] RoomTypes = new RoomType[]
            {
                new RoomType
                {
                    Id = 1,
                    Category = Category.OverwaterBungalow,
                    Name = "One-bedroom beach-view overwater bungalow",
                    RoomSize = "100 m2 (1,080 sq.ft.)",
                    Beds = "One king bed. One full sofa bed",
                    Occupancy = "3 adults or 2 adults and 2 children (up to the age of 12)",
                    MaxAdultCapacity = 3,
                    MaxChildCapacity = 2,
                    ExtraBeds = "One full sofa bed",
                    Location = "Overwater bungalow",
                    Bathroom = "One full bathroom",
                    Price = 300,
                    PhotoPath = "bungalow1.jpg"
                },
                new RoomType
                {
                    Id = 2,
                    Category = Category.OverwaterBungalow,
                    Name = "Two-bedroom overwater bungalow suite",
                    RoomSize = "207 m2 (2,228 sq.ft.)",
                    Beds = "Two king beds. Two full sofa beds",
                    Occupancy = "6 adults or 2 adults and 4 children (up to the age of 12)",
                    MaxAdultCapacity = 6,
                    MaxChildCapacity = 4,
                    ExtraBeds = "Two full sofa beds",
                    Location = "Overwater bungalow",
                    Bathroom = "Two full bathrooms",
                    Price = 500,
                    PhotoPath = "bungalow2.jpg"
                },
                new RoomType
                {
                    Id = 3,
                    Category = Category.OverwaterBungalow,
                    Name = "Two-bedroom overwater bungalow suite with plunge pool",
                    RoomSize = "207 m2 (2,228 sq.ft.)",
                    Beds = "One king bed and two queen beds. Two full sofa beds",
                    Occupancy = "6 adults or 2 adults and 4 children (up to the age of 12)",
                    MaxAdultCapacity = 6,
                    MaxChildCapacity = 4,
                    ExtraBeds = "Two full sofa beds",
                    Location = "Overwater bungalow",
                    Bathroom = "Two full bathrooms",
                    Price = 600,
                    PhotoPath = "bungalow3.jpg"
                },
                new RoomType
                {
                    Id = 4,
                    Category = Category.Room,
                    Name = "Deluxe beachfront room",
                    RoomSize = "59 m2 (640 sq.ft.)",
                    Beds = "One king bed. One rollaway",
                    Occupancy = "2 adults or 2 adults and 1 child (up to the age of 12)",
                    MaxAdultCapacity = 2,
                    MaxChildCapacity = 1,
                    ExtraBeds = "One rollaway",
                    Location = "Floors 1-4",
                    Bathroom = "One full bathroom",
                    Price = 300,
                    PhotoPath = "beachfront1.jpg"
                },
                new RoomType
                {
                    Id = 5,
                    Category = Category.Suite,
                    Name = "Beachfront one-bedroom suite",
                    RoomSize = "130 m2 (1,400 sq.ft.)",
                    Beds = "One king bed. One full sofa bed",
                    Occupancy = "3 adults or 2 adults and 2 children (up to the age of 12)",
                    MaxAdultCapacity = 3,
                    MaxChildCapacity = 2,
                    ExtraBeds = "One full sofa bed",
                    Location = "Floors 1, 5-6",
                    Bathroom = "Two full bathrooms",
                    Price = 450,
                    PhotoPath = "beachfront2.jpg"
                },
                new RoomType
                {
                    Id = 6,
                    Category = Category.VillaEstate,
                    Name = "Three-bedroom villa estate with plunge pool",
                    RoomSize = "500 m2 (5,380 sq.ft.)",
                    Beds = "Two king and two queen beds",
                    Occupancy = "6 adults or 2 adults and 4 children (up to the age of 12)",
                    MaxAdultCapacity = 6,
                    MaxChildCapacity = 4,
                    ExtraBeds = "One rollaway",
                    Location = "Secluded, with pedestrian access to beach and main building",
                    Bathroom = "Two full bathrooms and one-half bathroom",
                    Price = 1200,
                    PhotoPath = "villa1.jpg"
                },
                new RoomType
                { 
                    Id = 7,
                    Category = Category.VillaEstate,
                    Name = "Two-bedroom beachfront villa estate",
                    RoomSize = "300 m2 (3,228 sq.ft.)",
                    Beds = "One king and two queen beds. One full sofa bed",
                    Occupancy = "5 adults or 2 adults and 3 children (up to the age of 12)",
                    MaxAdultCapacity = 5,
                    MaxChildCapacity = 3,
                    ExtraBeds = "One full sofa bed",
                    Location = "Beachfront, with pedestrian access to main building",
                    Bathroom = "Two full bathrooms",
                    Price = 900,
                    PhotoPath = "villa2.jpg"
                },
                new RoomType
                {
                    Id = 8,
                    Category = Category.VillaEstate,
                    Name = "One-bedroom beachfront villa estate",
                    RoomSize = "253 m2 (2,722 sq.ft.)",
                    Beds = "One king bed. One full sofa bed",
                    Occupancy = "3 adults or 2 adults and 2 children (up to the age of 12)",
                    MaxAdultCapacity = 3,
                    MaxChildCapacity = 2,
                    ExtraBeds = "One full sofa bed",
                    Location = "Beachfront, with pedestrian access to main building",
                    Bathroom = "One full bathroom and one-half bathroom",
                    Price = 600,
                    PhotoPath = "villa3.jpg"
                }
            };

            Room[] Rooms = new Room[]
            {
                new Room
                {
                    Id = 1,
                    RoomTypeId = 1,
                    RoomNumber = "1",
                    View = "Lagoon"
                },
                new Room
                {
                    Id = 2,
                    RoomTypeId = 1,
                    RoomNumber = "2",
                    View = "Lagoon"
                },
                new Room
                {
                    Id = 3,
                    RoomTypeId = 1,
                    RoomNumber = "3",
                    View = "Mt. Suthep"
                },
                new Room
                {
                    Id = 4,
                    RoomTypeId = 1,
                    RoomNumber = "4",
                    View = "Mt. Suthep"
                },
                new Room
                {
                    Id = 5,
                    RoomTypeId = 2,
                    RoomNumber = "5",
                    View = "Lagoon"
                },
                new Room
                {
                    Id = 6,
                    RoomTypeId = 2,
                    RoomNumber = "6",
                    View = "Mt. Suthep"
                },
                new Room
                {
                    Id = 7,
                    RoomTypeId = 3,
                    RoomNumber = "7",
                    View = "Lagoon"
                },
                new Room
                {
                    Id = 8,
                    RoomTypeId = 3,
                    RoomNumber = "8",
                    View = "Mt. Suthep"
                },
                new Room
                {
                    Id = 9,
                    RoomTypeId = 4,
                    RoomNumber = "100",
                    View = "Beach"
                },
                new Room
                {
                    Id = 10,
                    RoomTypeId = 4,
                    RoomNumber = "201",
                    View = "Beach"
                },
                new Room
                {
                    Id = 11,
                    RoomTypeId = 4,
                    RoomNumber = "302",
                    View = "Garden"
                },
                new Room
                {
                    Id = 12,
                    RoomTypeId = 4,
                    RoomNumber = "402",
                    View = "Garden"
                },
                new Room
                {
                    Id = 13,
                    RoomTypeId = 5,
                    RoomNumber = "102",
                    View = "Beach"
                },
                new Room
                {
                    Id = 14,
                    RoomTypeId = 5,
                    RoomNumber = "500",
                    View = "Beach"
                },
                new Room
                {
                    Id = 15,
                    RoomTypeId = 5,
                    RoomNumber = "501",
                    View = "Garden"
                },
                new Room
                {
                    Id = 16,
                    RoomTypeId = 5,
                    RoomNumber = "600",
                    View = "Garden"
                },
                new Room
                {
                    Id = 17,
                    RoomTypeId = 8,
                    RoomNumber = "Paris",
                    View = "Mt. Suthep"
                },new Room
                {
                    Id = 18,
                    RoomTypeId = 8,
                    RoomNumber = "New York",
                    View = "Mt.Suthep"
                },
                new Room
                {
                    Id = 19,
                    RoomTypeId = 7,
                    RoomNumber = "Tokyo",
                    View = "Beach"
                },
                new Room
                {
                    Id = 20,
                    RoomTypeId = 7,
                    RoomNumber = "London",
                    View = "Beach"
                },
                new Room
                {
                    Id = 21,
                    RoomTypeId = 6,
                    RoomNumber = "Rome",
                    View = "Beach"
                },
                new Room
                {
                    Id = 22,
                    RoomTypeId = 6,
                    RoomNumber = "Amsterdam",
                    View = "Beach"
                },
                new Room
                {
                    Id = 23,
                    RoomTypeId = 6,
                    RoomNumber = "Cairo",
                    View = "Beach"
                }
            };

            modelBuilder.Entity<RoomType>().HasData(RoomTypes);
            modelBuilder.Entity<Room>().HasData(Rooms);
        }
    }
}
