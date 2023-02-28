using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class cart_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Car_CarId",
                table: "ShopCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "ShopCartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Car_CarId",
                table: "ShopCartItems",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Car_CarId",
                table: "ShopCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "ShopCartItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Car_CarId",
                table: "ShopCartItems",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
