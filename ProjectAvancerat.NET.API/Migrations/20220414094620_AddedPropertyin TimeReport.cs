using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAvancerat.NET.API.Migrations
{
    public partial class AddedPropertyinTimeReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "week",
                table: "Timereports",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "week",
                table: "Timereports");
        }
    }
}
