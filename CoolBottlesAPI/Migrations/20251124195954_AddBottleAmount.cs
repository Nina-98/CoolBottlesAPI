using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolBottlesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBottleAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Bottles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bottles");
        }
    }
}
