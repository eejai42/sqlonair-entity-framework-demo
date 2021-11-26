using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework_test2.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "CartItems");
        }
    }
}
