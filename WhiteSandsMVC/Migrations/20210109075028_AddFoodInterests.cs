using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteSandsMVC.Migrations
{
    public partial class AddFoodInterests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFoodInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    FoodInterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFoodInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFoodInterests_FoodInterests_FoodInterestId",
                        column: x => x.FoodInterestId,
                        principalTable: "FoodInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFoodInterests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodInterests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Restaurants & Bars" },
                    { 2, "Wine" },
                    { 3, "Brunch" },
                    { 4, "Cooking classes" },
                    { 5, "Farm to table" },
                    { 6, "Local specialties" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFoodInterests_FoodInterestId",
                table: "UserFoodInterests",
                column: "FoodInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoodInterests_UserId",
                table: "UserFoodInterests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFoodInterests");

            migrationBuilder.DropTable(
                name: "FoodInterests");
        }
    }
}
