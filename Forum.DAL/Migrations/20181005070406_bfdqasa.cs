using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DAL.Migrations
{
    public partial class bfdqasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserRoom_Id",
                table: "UserRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserRoom_Id",
                table: "UserRoom",
                column: "Id");
        }
    }
}
