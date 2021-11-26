using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework_test2.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "CartItems");
        }
    }
}
