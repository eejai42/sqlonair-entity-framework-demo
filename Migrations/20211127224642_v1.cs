using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework_test2.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentArrangement",
                columns: table => new
                {
                    PaymentArrangementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentArrangement", x => x.PaymentArrangementId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PaymentTerm = table.Column<int>(type: "int", nullable: true),
                    PaymentArrangementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_PaymentArrangement_PaymentArrangementId",
                        column: x => x.PaymentArrangementId,
                        principalTable: "PaymentArrangement",
                        principalColumn: "PaymentArrangementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaymentArrangement",
                columns: new[] { "PaymentArrangementId", "Term" },
                values: new object[,]
                {
                    { new Guid("67dcb6bc-a404-43e4-a870-f468c54935c3"), 15 },
                    { new Guid("727a9833-6de1-4c2d-85e0-b6744eee251f"), 30 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Name", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("463e8e24-61bf-4342-a64b-51338455ca83"), "Product A", 2.50m },
                    { new Guid("2e987de0-b832-4c8b-9da9-ceb01da2b4e1"), "Product B", 5.25m }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "PaymentArrangementId", "PaymentTerm", "PhoneNumber", "TaxRate" },
                values: new object[] { new Guid("8d592aa9-c729-4789-86c9-0c00b77884e8"), "EJ", new Guid("67dcb6bc-a404-43e4-a870-f468c54935c3"), 15, "555-123-4567", 0.055m });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "PaymentArrangementId", "PaymentTerm", "PhoneNumber", "TaxRate" },
                values: new object[] { new Guid("58e0f5cd-7de8-4c0b-8094-50d915e83b6e"), "Mary", new Guid("67dcb6bc-a404-43e4-a870-f468c54935c3"), 15, "123-456-7890", 0.025m });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "PaymentArrangementId", "PaymentTerm", "PhoneNumber", "TaxRate" },
                values: new object[] { new Guid("e199899f-3c5c-487e-975a-5f3773e6547a"), "Bob", new Guid("727a9833-6de1-4c2d-85e0-b6744eee251f"), 30, "808-808-8088", 0.0385m });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CartDate", "CartNumber", "CustomerId" },
                values: new object[] { new Guid("45484328-602e-4a62-b357-389df4ca57ff"), new DateTime(2021, 11, 27, 22, 46, 41, 718, DateTimeKind.Utc).AddTicks(2783), 1000, new Guid("8d592aa9-c729-4789-86c9-0c00b77884e8") });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CartDate", "CartNumber", "CustomerId" },
                values: new object[] { new Guid("798fd6d7-d4b9-41f3-92ac-94f91a94d90e"), new DateTime(2021, 11, 27, 22, 46, 41, 718, DateTimeKind.Utc).AddTicks(5745), 1002, new Guid("58e0f5cd-7de8-4c0b-8094-50d915e83b6e") });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CartDate", "CartNumber", "CustomerId" },
                values: new object[] { new Guid("50946c2c-83cf-4c9c-bccc-7cc9c6d87f41"), new DateTime(2021, 11, 27, 22, 46, 41, 718, DateTimeKind.Utc).AddTicks(5736), 1001, new Guid("e199899f-3c5c-487e-975a-5f3773e6547a") });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartItemId", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("03f1c51c-4106-4ad0-b6d3-31d9fd493ce1"), new Guid("45484328-602e-4a62-b357-389df4ca57ff"), new Guid("463e8e24-61bf-4342-a64b-51338455ca83"), 1m },
                    { new Guid("804acd71-bf7e-4ca1-9b35-606a31069ca7"), new Guid("45484328-602e-4a62-b357-389df4ca57ff"), new Guid("2e987de0-b832-4c8b-9da9-ceb01da2b4e1"), 25m },
                    { new Guid("5d515c3b-e9fd-416c-8823-8427a89778ab"), new Guid("798fd6d7-d4b9-41f3-92ac-94f91a94d90e"), new Guid("2e987de0-b832-4c8b-9da9-ceb01da2b4e1"), 6m },
                    { new Guid("aed01c16-5720-4996-8c83-adbf2b7efb3e"), new Guid("50946c2c-83cf-4c9c-bccc-7cc9c6d87f41"), new Guid("463e8e24-61bf-4342-a64b-51338455ca83"), 125m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentArrangementId",
                table: "Customer",
                column: "PaymentArrangementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PaymentArrangement");
        }
    }
}
