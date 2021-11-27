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
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerm = table.Column<int>(type: "int", nullable: false),
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
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    { new Guid("0da423a4-9a3e-429a-a5f4-40b1520304cf"), 15 },
                    { new Guid("28d814bf-3c4a-46e8-9b32-abba46ff179a"), 30 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Name", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("35eeb65b-b9c4-4c44-a30f-d78cf5933726"), "Product A", 2.50m },
                    { new Guid("c0abc7ec-4932-48ce-9697-76d0bac9ced8"), "Product B", 5.25m }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "PaymentArrangementId", "PaymentTerm", "PhoneNumber", "TaxRate" },
                values: new object[] { new Guid("5f08a8db-13b7-4c64-9d9b-9f9bb8589381"), "EJ", new Guid("0da423a4-9a3e-429a-a5f4-40b1520304cf"), 0, "555-123-4567", 0m });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "PaymentArrangementId", "PaymentTerm", "PhoneNumber", "TaxRate" },
                values: new object[] { new Guid("d3953001-b917-4484-8dae-ca9b60610e30"), "Mary", new Guid("0da423a4-9a3e-429a-a5f4-40b1520304cf"), 0, "123-456-7890", 0m });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "PaymentArrangementId", "PaymentTerm", "PhoneNumber", "TaxRate" },
                values: new object[] { new Guid("18026425-03c2-42b6-9080-c7df1afed350"), "Bob", new Guid("28d814bf-3c4a-46e8-9b32-abba46ff179a"), 0, "808-808-8088", 0m });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CartDate", "CartNumber", "CustomerId" },
                values: new object[] { new Guid("41973484-2eda-403a-8f59-84afb6c66a85"), new DateTime(2021, 11, 27, 21, 32, 47, 527, DateTimeKind.Utc).AddTicks(1069), 0, new Guid("5f08a8db-13b7-4c64-9d9b-9f9bb8589381") });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CartDate", "CartNumber", "CustomerId" },
                values: new object[] { new Guid("b97a18ea-b650-4c12-bee5-2039c33204f4"), new DateTime(2021, 11, 27, 21, 32, 47, 527, DateTimeKind.Utc).AddTicks(3095), 0, new Guid("d3953001-b917-4484-8dae-ca9b60610e30") });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CartDate", "CartNumber", "CustomerId" },
                values: new object[] { new Guid("03b6cb94-5a14-4cda-8a8e-7f7cb508f429"), new DateTime(2021, 11, 27, 21, 32, 47, 527, DateTimeKind.Utc).AddTicks(3087), 0, new Guid("18026425-03c2-42b6-9080-c7df1afed350") });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartItemId", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("34b80451-2750-4906-bc36-e3612d97ae37"), new Guid("41973484-2eda-403a-8f59-84afb6c66a85"), new Guid("35eeb65b-b9c4-4c44-a30f-d78cf5933726"), 1m },
                    { new Guid("1d5e8dcc-1431-430e-abd4-291fd79c9c5d"), new Guid("41973484-2eda-403a-8f59-84afb6c66a85"), new Guid("c0abc7ec-4932-48ce-9697-76d0bac9ced8"), 25m },
                    { new Guid("c3453ef4-4d9f-4b06-8c9a-85c0a9818574"), new Guid("b97a18ea-b650-4c12-bee5-2039c33204f4"), new Guid("c0abc7ec-4932-48ce-9697-76d0bac9ced8"), 6m },
                    { new Guid("bb59e508-608b-4728-86ef-e4adccbd33e7"), new Guid("03b6cb94-5a14-4cda-8a8e-7f7cb508f429"), new Guid("35eeb65b-b9c4-4c44-a30f-d78cf5933726"), 125m }
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
