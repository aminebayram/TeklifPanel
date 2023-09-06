using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomerOpenAddress050923 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "OpenAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenAddress",
                table: "Customers",
                newName: "Address");
        }
    }
}
