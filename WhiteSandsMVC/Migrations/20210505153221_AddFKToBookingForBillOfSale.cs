using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteSandsMVC.Migrations
{
    public partial class AddFKToBookingForBillOfSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BillsOfSale_BillOfSaleId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "BillOfSaleId",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BillsOfSale_BillOfSaleId",
                table: "Bookings",
                column: "BillOfSaleId",
                principalTable: "BillsOfSale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BillsOfSale_BillOfSaleId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "BillOfSaleId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BillsOfSale_BillOfSaleId",
                table: "Bookings",
                column: "BillOfSaleId",
                principalTable: "BillsOfSale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
