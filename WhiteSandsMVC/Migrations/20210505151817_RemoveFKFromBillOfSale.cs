using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteSandsMVC.Migrations
{
    public partial class RemoveFKFromBillOfSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillsOfSale_Bookings_BookingId",
                table: "BillsOfSale");

            migrationBuilder.DropIndex(
                name: "IX_BillsOfSale_BookingId",
                table: "BillsOfSale");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "BillsOfSale");

            migrationBuilder.AddColumn<int>(
                name: "BillOfSaleId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BillOfSaleId",
                table: "Bookings",
                column: "BillOfSaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BillsOfSale_BillOfSaleId",
                table: "Bookings",
                column: "BillOfSaleId",
                principalTable: "BillsOfSale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BillsOfSale_BillOfSaleId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BillOfSaleId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BillOfSaleId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "BillsOfSale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillsOfSale_BookingId",
                table: "BillsOfSale",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillsOfSale_Bookings_BookingId",
                table: "BillsOfSale",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
