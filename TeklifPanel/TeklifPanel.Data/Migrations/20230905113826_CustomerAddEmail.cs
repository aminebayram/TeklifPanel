using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeklifPanel.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomerAddEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Email",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");
        }
    }
}
