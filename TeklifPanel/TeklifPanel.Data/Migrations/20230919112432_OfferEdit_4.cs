using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class OfferEdit_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Offer");

            migrationBuilder.AddColumn<int>(
                name: "OfferNumber",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferNumber",
                table: "Offer");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
