using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DAL.Migrations
{
    public partial class NameChngedToSomeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Rooms_ThreadId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ThreadId",
                table: "Posts",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ThreadId",
                table: "Posts",
                newName: "IX_Posts_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Rooms_RoomId",
                table: "Posts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Rooms_RoomId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Posts",
                newName: "ThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_RoomId",
                table: "Posts",
                newName: "IX_Posts_ThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Rooms_ThreadId",
                table: "Posts",
                column: "ThreadId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
