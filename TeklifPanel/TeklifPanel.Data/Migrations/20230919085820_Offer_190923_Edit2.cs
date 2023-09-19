using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class Offer_190923_Edit2 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "CustomerContactId",
                table: "Offer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Offer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Addresses_AddressId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_CustomerContacts_CustomerContactId",
                table: "Offer");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerContactId",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
