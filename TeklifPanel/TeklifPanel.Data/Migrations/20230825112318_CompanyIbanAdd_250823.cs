using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompanyIbanAdd_250823 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iban_Companies_CompanyId",
                table: "Iban");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iban",
                table: "Iban");

            migrationBuilder.RenameTable(
                name: "Iban",
                newName: "Ibans");

            migrationBuilder.RenameIndex(
                name: "IX_Iban_CompanyId",
                table: "Ibans",
                newName: "IX_Ibans_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ibans",
                table: "Ibans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ibans_Companies_CompanyId",
                table: "Ibans",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ibans_Companies_CompanyId",
                table: "Ibans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ibans",
                table: "Ibans");

            migrationBuilder.RenameTable(
                name: "Ibans",
                newName: "Iban");

            migrationBuilder.RenameIndex(
                name: "IX_Ibans_CompanyId",
                table: "Iban",
                newName: "IX_Iban_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iban",
                table: "Iban",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Iban_Companies_CompanyId",
                table: "Iban",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
