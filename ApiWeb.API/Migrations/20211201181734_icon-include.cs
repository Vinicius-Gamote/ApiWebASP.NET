using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.API.Migrations
{
    public partial class iconinclude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIcon",
                table: "User",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIcon",
                table: "User");
        }
    }
}
