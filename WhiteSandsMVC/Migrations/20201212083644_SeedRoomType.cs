using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteSandsMVC.Migrations
{
    public partial class SeedRoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Bathroom", "Beds", "Category", "ExtraBeds", "Location", "MaxAdultCapacity", "MaxChildCapacity", "Name", "Occupancy", "Price", "RoomSize" },
                values: new object[,]
                {
                    { 1, "One full bathroom", "One king bed. One full sofa bed", 0, "One full sofa bed", "Overwater bungalow", (byte)3, (byte)2, "One-bedroom beach-view overwater bungalow", "3 adults or 2 adults and 2 children (up to the age of 12)", 300m, "100 m2 (1,080 sq.ft.)" },
                    { 2, "Two full bathrooms", "Two king beds. Two full sofa beds", 0, "Two full sofa beds", "Overwater bungalow", (byte)6, (byte)4, "Two-bedroom overwater bungalow suite", "6 adults or 2 adults and 4 children (up to the age of 12)", 500m, "207 m2 (2,228 sq.ft.)" },
                    { 3, "Two full bathrooms", "One king bed and two queen beds. Two full sofa beds", 0, "Two full sofa beds", "Overwater bungalow", (byte)6, (byte)4, "Two-bedroom overwater bungalow suite with plunge pool", "6 adults or 2 adults and 4 children (up to the age of 12)", 600m, "207 m2 (2,228 sq.ft.)" },
                    { 4, "One full bathroom", "One king bed. One rollaway", 1, "One rollaway", "Floors 1-4", (byte)2, (byte)1, "Deluxe beachfront room", "2 adults or 2 adults and 1 child (up to the age of 12)", 300m, "59 m2 (640 sq.ft.)" },
                    { 5, "Two full bathrooms", "One king bed. One full sofa bed", 2, "One full sofa bed", "Floors 1, 5-6", (byte)3, (byte)2, "Beachfront one-bedroom suite", "3 adults or 2 adults and 2 children (up to the age of 12)", 450m, "130 m2 (1,400 sq.ft.)" },
                    { 6, "Two full bathrooms and one-half bathroom", "Two king and two queen beds", 3, "One rollaway", "Secluded, with pedestrian access to beach and main building", (byte)6, (byte)4, "Three-bedroom villa estate with plunge pool", "6 adults or 2 adults and 4 children (up to the age of 12)", 1200m, "500 m2 (5,380 sq.ft.)" },
                    { 7, "Two full bathrooms", "One king and two queen beds. One full sofa bed", 3, "One full sofa bed", "Beachfront, with pedestrian access to main building", (byte)5, (byte)3, "Two-bedroom beachfront villa estate", "5 adults or 2 adults and 3 children (up to the age of 12)", 900m, "300 m2 (3,228 sq.ft.)" },
                    { 8, "One full bathroom and one-half bathroom", "One king bed. One full sofa bed", 3, "One full sofa bed", "Beachfront, with pedestrian access to main building", (byte)3, (byte)2, "One-bedroom beachfront villa estate", "3 adults or 2 adults and 2 children (up to the age of 12)", 600m, "253 m2 (2,722 sq.ft.)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
