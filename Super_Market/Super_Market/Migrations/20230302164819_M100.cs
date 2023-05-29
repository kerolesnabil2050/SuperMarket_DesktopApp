using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Market.Migrations
{
    /// <inheritdoc />
    public partial class M100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscount",
                table: "sellinvoces",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscount",
                table: "sellinvoces");
        }
    }
}
