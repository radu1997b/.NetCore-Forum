using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DAL.Migrations
{
    public partial class UserPhotoPathAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPhotoPath",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPhotoPath",
                table: "AspNetUsers");
        }
    }
}
