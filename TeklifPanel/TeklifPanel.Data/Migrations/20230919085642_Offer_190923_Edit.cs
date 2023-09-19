using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class Offer_190923_Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Addresses_AddressId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_CustomerContacts_CustomerContactId",
                table: "Offer");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Addresses_AddressId",
                table: "Offer",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_CustomerContacts_CustomerContactId",
                table: "Offer",
                column: "CustomerContactId",
                principalTable: "CustomerContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Addresses_AddressId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_CustomerContacts_CustomerContactId",
                table: "Offer");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Addresses_AddressId",
                table: "Offer",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_CustomerContacts_CustomerContactId",
                table: "Offer",
                column: "CustomerContactId",
                principalTable: "CustomerContacts",
                principalColumn: "Id");
        }
    }
}
