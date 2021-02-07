using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteSandsMVC.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNumberCountryCode = table.Column<string>(nullable: true),
                    NameOnCreditCard = table.Column<string>(nullable: true),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    CreditCardExpiryMonth = table.Column<string>(nullable: true),
                    CreditCardExpiryYear = table.Column<string>(nullable: true),
                    SubscribedToEmailList = table.Column<bool>(nullable: false),
                    MattressPreference = table.Column<string>(nullable: true, defaultValue: "Mattress - Signature pocket spring (medium firmness)"),
                    PillowPreference = table.Column<string>(nullable: true, defaultValue: "Pillows - Feather"),
                    SmokingPreference = table.Column<string>(nullable: true, defaultValue: "Non-smoking room")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    ConfirmEmail = table.Column<string>(nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    NameOnCreditCard = table.Column<string>(maxLength: 50, nullable: false),
                    CreditCardNumber = table.Column<string>(maxLength: 50, nullable: false),
                    CreditCardExpiryMonth = table.Column<string>(maxLength: 10, nullable: false),
                    CreditCardExpiryYear = table.Column<string>(maxLength: 10, nullable: false),
                    SubscribedToEmailList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<string>(maxLength: 10, nullable: false),
                    View = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    RoomSize = table.Column<string>(maxLength: 100, nullable: false),
                    Beds = table.Column<string>(maxLength: 100, nullable: false),
                    Occupancy = table.Column<string>(maxLength: 100, nullable: false),
                    MaxAdultCapacity = table.Column<byte>(nullable: false),
                    MaxChildCapacity = table.Column<byte>(nullable: false),
                    ExtraBeds = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Bathroom = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    PhotoPath = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(type: "money", nullable: false),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    Adults = table.Column<byte>(nullable: false),
                    Children = table.Column<byte>(nullable: false),
                    Promo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTravelInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    TravelInterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTravelInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTravelInterests_TravelInterests_TravelInterestId",
                        column: x => x.TravelInterestId,
                        principalTable: "TravelInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTravelInterests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Bathroom", "Beds", "Category", "ExtraBeds", "Location", "MaxAdultCapacity", "MaxChildCapacity", "Name", "Occupancy", "PhotoPath", "Price", "RoomSize" },
                values: new object[,]
                {
                    { 8, "One full bathroom and one-half bathroom", "One king bed. One full sofa bed", 3, "One full sofa bed", "Beachfront, with pedestrian access to main building", (byte)3, (byte)2, "One-bedroom beachfront villa estate", "3 adults or 2 adults and 2 children (up to the age of 12)", "villa3.jpg", 600m, "253 m2 (2,722 sq.ft.)" },
                    { 7, "Two full bathrooms", "One king and two queen beds. One full sofa bed", 3, "One full sofa bed", "Beachfront, with pedestrian access to main building", (byte)5, (byte)3, "Two-bedroom beachfront villa estate", "5 adults or 2 adults and 3 children (up to the age of 12)", "villa2.jpg", 900m, "300 m2 (3,228 sq.ft.)" },
                    { 6, "Two full bathrooms and one-half bathroom", "Two king and two queen beds", 3, "One rollaway", "Secluded, with pedestrian access to beach and main building", (byte)6, (byte)4, "Three-bedroom villa estate with plunge pool", "6 adults or 2 adults and 4 children (up to the age of 12)", "villa1.jpg", 1200m, "500 m2 (5,380 sq.ft.)" },
                    { 5, "Two full bathrooms", "One king bed. One full sofa bed", 2, "One full sofa bed", "Floors 1, 5-6", (byte)3, (byte)2, "Beachfront one-bedroom suite", "3 adults or 2 adults and 2 children (up to the age of 12)", "beachfront2.jpg", 450m, "130 m2 (1,400 sq.ft.)" },
                    { 4, "One full bathroom", "One king bed. One rollaway", 1, "One rollaway", "Floors 1-4", (byte)2, (byte)1, "Deluxe beachfront room", "2 adults or 2 adults and 1 child (up to the age of 12)", "beachfront1.jpg", 300m, "59 m2 (640 sq.ft.)" },
                    { 3, "Two full bathrooms", "One king bed and two queen beds. Two full sofa beds", 0, "Two full sofa beds", "Overwater bungalow", (byte)6, (byte)4, "Two-bedroom overwater bungalow suite with plunge pool", "6 adults or 2 adults and 4 children (up to the age of 12)", "bungalow3.jpg", 600m, "207 m2 (2,228 sq.ft.)" },
                    { 2, "Two full bathrooms", "Two king beds. Two full sofa beds", 0, "Two full sofa beds", "Overwater bungalow", (byte)6, (byte)4, "Two-bedroom overwater bungalow suite", "6 adults or 2 adults and 4 children (up to the age of 12)", "bungalow2.jpg", 500m, "207 m2 (2,228 sq.ft.)" },
                    { 1, "One full bathroom", "One king bed. One full sofa bed", 0, "One full sofa bed", "Overwater bungalow", (byte)3, (byte)2, "One-bedroom beach-view overwater bungalow", "3 adults or 2 adults and 2 children (up to the age of 12)", "bungalow1.jpg", 300m, "100 m2 (1,080 sq.ft.)" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomNumber", "RoomTypeId", "View" },
                values: new object[,]
                {
                    { 1, "1", 1, "Lagoon" },
                    { 23, "Cairo", 6, "Beach" },
                    { 21, "Rome", 6, "Beach" },
                    { 20, "London", 7, "Beach" },
                    { 19, "Tokyo", 7, "Beach" },
                    { 18, "New York", 8, "Mt.Suthep" },
                    { 17, "Paris", 8, "Mt. Suthep" },
                    { 22, "Amsterdam", 6, "Beach" },
                    { 15, "501", 5, "Garden" },
                    { 2, "2", 1, "Lagoon" },
                    { 16, "600", 5, "Garden" },
                    { 4, "4", 1, "Mt. Suthep" },
                    { 5, "5", 2, "Lagoon" },
                    { 6, "6", 2, "Mt. Suthep" },
                    { 7, "7", 3, "Lagoon" },
                    { 8, "8", 3, "Mt. Suthep" },
                    { 3, "3", 1, "Mt. Suthep" },
                    { 10, "201", 4, "Beach" },
                    { 11, "302", 4, "Garden" },
                    { 12, "402", 4, "Garden" },
                    { 13, "102", 5, "Beach" },
                    { 14, "500", 5, "Beach" },
                    { 9, "100", 4, "Beach" }
                });

            migrationBuilder.InsertData(
                table: "TravelInterests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Shopping" },
                    { 9, "Art and Culture" },
                    { 8, "Adventure Travel" },
                    { 7, "City Escape" },
                    { 6, "Vacation Rental" },
                    { 3, "Friends Getaway" },
                    { 4, "Solo Travel" },
                    { 2, "Family Getaway" },
                    { 1, "Couples Getaway" },
                    { 11, "Sporting Events" },
                    { 5, "Beach Vacation" },
                    { 12, "Culinary Travel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomTypeId",
                table: "Bookings",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTravelInterests_TravelInterestId",
                table: "UserTravelInterests",
                column: "TravelInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTravelInterests_UserId",
                table: "UserTravelInterests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "UserTravelInterests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "TravelInterests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
