using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprintathonAPI.Migrations
{
    /// <inheritdoc />
    public partial class Ittais_Changes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "GarmentTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "GarmentTypes");
        }
    }
}
