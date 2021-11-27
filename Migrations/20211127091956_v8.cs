using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework_test2.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentArrangementId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentArrangementTerm",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDue",
                table: "Cart",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentArrangementId",
                table: "Customer",
                column: "PaymentArrangementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PaymentArrangement_PaymentArrangementId",
                table: "Customer",
                column: "PaymentArrangementId",
                principalTable: "PaymentArrangement",
                principalColumn: "PaymentArrangementId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PaymentArrangement_PaymentArrangementId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "PaymentArrangement");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PaymentArrangementId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PaymentArrangementId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PaymentArrangementTerm",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDue",
                table: "Cart");
        }
    }
}
