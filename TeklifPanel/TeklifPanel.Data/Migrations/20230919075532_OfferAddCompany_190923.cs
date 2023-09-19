using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class OfferAddCompany_190923 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_CompanyId",
                table: "Offer",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Companies_CompanyId",
                table: "Offer",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Companies_CompanyId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_CompanyId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Offer");
        }
    }
}
