using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteSandsMVC.Migrations
{
    public partial class AddHealthInterests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHealthInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    HealthInterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHealthInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHealthInterests_HealthInterests_HealthInterestId",
                        column: x => x.HealthInterestId,
                        principalTable: "HealthInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHealthInterests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HealthInterests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fitness" },
                    { 2, "Spa" },
                    { 3, "Yoga" },
                    { 4, "Nature Excursions" },
                    { 5, "Skiing" },
                    { 6, "Golfing" },
                    { 7, "Diving" },
                    { 8, "Surfing" },
                    { 9, "Other water sports" },
                    { 10, "Horseback riding" },
                    { 11, "Meditation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHealthInterests_HealthInterestId",
                table: "UserHealthInterests",
                column: "HealthInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHealthInterests_UserId",
                table: "UserHealthInterests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHealthInterests");

            migrationBuilder.DropTable(
                name: "HealthInterests");
        }
    }
}
