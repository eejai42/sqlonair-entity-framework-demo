using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework_test2.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CartQuantity",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CartTotal",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CartTotal",
                table: "Customer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsVIP",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate",
                table: "Customer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerTaxRate",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CustomerPaymentTerm",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CustomerTaxRate",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartTotal",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartTotal",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsVIP",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PaymentTerm",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CustomerTaxRate",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CustomerPaymentTerm",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CustomerTaxRate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Cart");
        }
    }
}
