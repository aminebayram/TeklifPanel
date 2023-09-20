using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class OfferAddDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Addresses_AddressId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_AddressId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "DateOfSend",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "KDV",
                table: "Offer");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Offer",
                newName: "Discount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Offer",
                newName: "SellPrice");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Offer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyPrice",
                table: "Offer",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfSend",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "KDV",
                table: "Offer",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_AddressId",
                table: "Offer",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Addresses_AddressId",
                table: "Offer",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
